
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async_test
{
	public partial class Form1 : Form
	{
		// Fields

		private bool m_running = false;
		CancellationTokenSource m_cancelTokenSource = null;

		/// <summary>Constructor</summary>
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>Handles click on button</summary>
		/// <param name="sender">Button</param>
		/// <param name="e">Empty event arguments</param>
		private async void button_Click(object sender, EventArgs e)
		{
			// Running flag will be true if button was already clicked, but will reset to false after completed
			if (!m_running)
			{
				// Update display to indicate we are running
				m_running = true;
				statusLabel.Text = "Working";
				button.Text = "Cancel";

				// Create progress and cancel objects
				Progress<int> prog = new Progress<int>(SetProgress);
				m_cancelTokenSource = new CancellationTokenSource();
				try
				{
					// Launch the process. After launching, will "return" from this method.
					await SlowProcess(prog, m_cancelTokenSource.Token);

					// But, after complete processing will continue here
					statusLabel.Text = "Done";
				}
				catch (OperationCanceledException)
				{
					// If the operation was cancelled, the exception will be thrown as though it came from the await line
					statusLabel.Text = "Canceled";
				}
				finally
				{
					// Reset the UI
					button.Text = "Start";
					m_running = false;
					m_cancelTokenSource = null;
				}
			}
			else
			{
				// User hit the Cancel button, so signal the cancel token and put a temporary message in the UI
				statusLabel.Text = "Waiting to cancel...";
				m_cancelTokenSource.Cancel();
			}
		}

		/// <summary>Updates the progress display</summary>
		/// <param name="value">The new progress value</param>
		private void SetProgress(int value)
		{
			// Add 1 so that progress is "completed"
			int adjustedValue = value + 1; 

			// Make sure value is in range
			adjustedValue = Math.Max(adjustedValue, progressBar.Minimum);
			adjustedValue = Math.Min(adjustedValue, progressBar.Maximum);

            progressBar.Value = adjustedValue;
		}

		/// <summary>Creates a Task that does some makework, but shows progress, and allows for cancel</summary>
		/// <param name="prog">Progress object that allows for reporting of current progress</param>
		/// <param name="ct">Cancellation token that allows code to determine if the user has attempted to cancel the operation</param>
		private Task SlowProcess(IProgress<int> prog, CancellationToken ct)
		{
			string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Files");
			string[] files = System.IO.Directory.GetFiles(path);

			//Perform time consuming operation by setting ParallelOptions.MaxDegreeOfParallelism attibute
			//This will make parallelism dependent on the number of CPU cores.

			var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
			Parallel.ForEach(files, options, file =>
			{
				using (StreamWriter w = File.AppendText(file))
				{
					w.WriteLine("hello");
				}
			});

			//Performing the time consuming operation through Asynchrous task
			return Task.Run(() =>
			{
				#region This region can be uncommented to test the progress bar
				//for (int i = 0; i < 100; i++)
				//{
				//	// Check to see if the user cancelled. If so, throw an exception (which will be caught in the button_Click method).
				//	// Note: The debugger might stop and show an "OperationCanceledExcpetion was unhandled by user code" popup. You can
				//	//       ignore this (and choose not to show it again for this type of exception). The debugger simply cannot determine
				//	//       that there is actually a catch, since it is around the await call rather than the method call.
				//	ct.ThrowIfCancellationRequested();

				//	// Update progress bar
				//	prog.Report(i);

				//	// Make work
				//	Thread.Sleep(200);
				//}
				#endregion
			
				foreach (string file in files)
				{
					using (StreamWriter w = File.AppendText(file))
					{
						w.WriteLine("hello");
					}
				}

			}, ct);
			
		}
	}
}
