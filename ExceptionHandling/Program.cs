using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExceptionHandling
{
    /// <summary>
    /// The Program that demonstrates the catching of System.IndexOutOfRangeException 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {              
                string[] list = new string[5];
                list[0] = "Sunday";
                list[1] = "Monday";
                list[2] = "Tuesday";
                list[3] = "Wednesday";
                list[4] = "Thursday";

                for (int i = 0; i <= 5; i++)
                {
                    if (list.GetLength(0) == i)
                    {
                        throw new CustomIndexOutOfRangeException();
                    }
                    else
                    {
                        Console.WriteLine(list[i].ToString());
                    }
                }
            }
            catch (CustomIndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ReadFileContent();
            Console.ReadLine();
        }

        /// <summary>
        /// The method to read the file content
        /// </summary>
        static void ReadFileContent()
        {
            StreamReader file = null;
            try
            {
               file = new System.IO.StreamReader(@"D:\myfolder\myfile.txt");               
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                char[] buffer = new char[10];
                file.ReadBlock(buffer, 0, buffer.Length);
                file.Close();
            }
        }
    }

    /// <summary>
    /// The Custom exceptiCustomIndexOutOfRangeExceptionon class
    /// </summary>    
    public class CustomIndexOutOfRangeException : Exception
    {
        public CustomIndexOutOfRangeException() : base("This is my Custom Exception Message")
        {

        }
    }
   
}
