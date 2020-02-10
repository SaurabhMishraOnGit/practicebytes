using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Program
    {
        static IList<Employee> employeeList = null;
        static IList<Department> departmentList = null;

        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Step-1 : Create and populate the lists for Employee and Departments
            FillDataInLists();

            //Step-2: Retreive the details from the above lists
            RetreiveDetailsFromLists();
        }

        /// <summary>
        /// The Method responsible to get the details from the lists
        /// </summary>
        private static void RetreiveDetailsFromLists()
        {
            //List of employee details with Odd salary value using Parallel LINQ
            var employeedWithOddSalaries = employeeList.AsParallel().Where(s => (s.Salary) % 2 != 0).ToList();

            //Using both the lists, Get all the employee objects whose department exist in department list
            var deptCodes = new HashSet<string>(departmentList.Select(a => a.Name));
            var result = employeeList.Where(b => deptCodes.Contains(b.Department));

            //Group the employees under a department (Point 1)
            var employeeGroupsOnDepts = from emp in result
                                        group emp by emp.Department into g
                                        select new { Department = g.Key, test = g.ToList() };

            //Highest salary under each department (Point 2)
            var higestSalaryUnderEachDept = from emp in result
                                            group emp by emp.Department into g
                                            select new { Department = g.Key, highestSalary = g.OrderByDescending(m => m.Salary).FirstOrDefault() };

            ////Incrementing salary based on Gender (Point 3)
            foreach (var item in result)
            {
                int isIncremented = item.Gender == "Male" ? item.Salary += 1000 : item.Salary += 1500;              
            }           

            //Get the details of the Manager (Manager ID and Name) whose reportees > 2 using self join (Point 4)
            var q = (from employee in result
                     join employee2 in result on employee.EmployeeID equals employee2.ManagerID
                     select new { ManagerID = employee.EmployeeID, Name = employee.Name }).FirstOrDefault();

            //Deep copying the Salary details from employees (Point 5)
            List<Employee> copiedResult = result.Select(p => (Employee)p.Clone()).ToList();

            //Get the salary details of employees within a specific manager with ID '201' and increment the salary by 10%
            foreach (var salariedEmployee in copiedResult.Where(p => p.ManagerID == 201))
            {
                salariedEmployee.Salary = Convert.ToInt32(salariedEmployee.Salary + (0.1 * salariedEmployee.Salary));
            }
        }

        /// <summary>
        /// The method is responsible to populate the data in the ILists for employee and departments
        /// </summary>
        private static void FillDataInLists()
        {
            employeeList = new List<Employee>
            {
                new Employee { EmployeeID = 101, Name = "Saurabh Mishra", Age = 30, Gender = "Male", Salary = 10500, Department = "DOTNET", ManagerID = 201 },
                new Employee { EmployeeID = 102, Name = "Sumanth Komravelli", Age = 32, Gender = "Male", Salary = 12001, Department = "DOTNET", ManagerID = 201 },
                new Employee { EmployeeID = 103, Name = "Suchetana Mukherjee", Age = 30, Gender = "Female", Salary = 12005, Department = "DOTNET", ManagerID = 201 },
                new Employee { EmployeeID = 201, Name = "Anuranjan Kukreja", Age = 35, Gender = "Male", Salary = 15000, Department = "DOTNET", ManagerID = 301 },
                new Employee { EmployeeID = 201, Name = "Nagarjuna Golla", Age = 29, Gender = "Male", Salary = 11007, Department = "TESTING", ManagerID = 201 },
                new Employee { EmployeeID = 201, Name = "Mayank Tiwari", Age = 27, Gender = "Male", Salary = 10000, Department = "JAVA", ManagerID = 301 },
                new Employee { EmployeeID = 201, Name = "Krishna Kishore", Age = 32, Gender = "Male", Salary = 14000, Department = "JAVA", ManagerID = 301 },
                new Employee { EmployeeID = 201, Name = "Kumar Posa", Age = 32, Gender = "Male", Salary = 14032, Department = "TESTING", ManagerID = 301 },
            };

            departmentList = new List<Department>
            {
                new Department { DepartmentID = 100, Name = "DOTNET"},
                new Department { DepartmentID = 200, Name = "JAVA"},
                new Department { DepartmentID = 300, Name = "TESTING"},
            };
        }
    }

    /// <summary>
    /// The Employee class
    /// </summary>
    [Serializable]
    public class Employee : ICloneable
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int Salary { get; set; }

        public string Department { get; set; }

        public int ManagerID { get; set; }

        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }
    }

    /// <summary>
    /// The Department class
    /// </summary>
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }
    }

}
