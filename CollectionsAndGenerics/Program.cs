using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentDetails = Student.GetSampleData();

            //Search the collection and print the student details for student with Registration number say 1022
            Student.Print(studentDetails.Where(p => p.RegistrationNumber == 1022).Select(p => p).FirstOrDefault());

            //Sort the array based on total score and return it.
             Array.Sort(studentDetails, delegate (Student x, Student y) { return x.totalScore.CompareTo(y.totalScore); });
        }
    }

    /// <summary>
    /// The class Student
    /// </summary>
    public class Student
    {
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public int PhysicsScore { get; set; }
        public int ChemistryScore { get; set; }
        public int MathScore { get; set; }
        public int BiologyScore { get; set; }
        public int totalScore { get; set; }

        public Student(string name, int registrationNumber, int physicsScore, int chemistryScore, int mathScore, int biologyScore)
        {
            this.Name = name; this.RegistrationNumber = registrationNumber;
            this.PhysicsScore = physicsScore;
            this.ChemistryScore = chemistryScore;
            this.MathScore = mathScore;
            this.totalScore = mathScore + PhysicsScore + ChemistryScore + BiologyScore;
        }

        public static void Print(Student objStudent)
        {           
            Console.WriteLine("Name:{0};Reg Number:{1};Maths:{2};Phy:{3};Chem:{4};Bio:{5};Total:{6}", objStudent.Name, objStudent.RegistrationNumber, objStudent.MathScore, objStudent.PhysicsScore, objStudent.ChemistryScore, objStudent.BiologyScore, objStudent.totalScore);
        }

        public static Student[] GetSampleData()
        {
            Student[] arr = new Student[]
        {
          new Student("zz", 1025, 65, 58, 93, 76),
          new Student("yy", 1024, 66, 60, 91, 84),
          new Student("xx", 1023, 67, 62, 90, 77),
          new Student("ww", 1022, 68, 64, 89, 83),
          new Student("vv", 1021, 69, 66, 87, 82),
          new Student("uu", 1020, 70, 68, 87, 78),
          new Student("tt", 1019, 71, 70, 85, 81),
          new Student("ss", 1018, 72, 72, 84, 76),
          new Student("rr", 1017, 73, 74, 83, 80),
          new Student("qq", 1016, 74, 76, 81, 79),
          new Student("pp", 1015, 75, 78, 81, 78),
          new Student("oo", 1014, 76, 80, 79, 78),
          new Student("nn", 1013, 77, 82, 78, 80),
          new Student("mm", 1012, 78, 84, 77, 69),
          new Student("ll", 1011, 79, 86, 75, 70),
          new Student("kk", 1010, 80, 88, 75, 82),
          new Student("JJ", 1009, 81, 90, 73, 71),
          new Student("II", 1008, 82, 92, 72, 84),
          new Student("HH", 1007, 83, 94, 71, 72),
          new Student("GG", 1006, 84, 96, 69, 73),
          new Student("FF", 1005, 85, 98, 69, 86),
          new Student("EE", 1004, 86, 70, 67, 74),
          new Student("DD", 1003, 87, 71, 66, 88),
          new Student("CC", 1002, 88, 72, 65, 75),
          new Student("BB", 1001, 89, 73, 63, 90),
          new Student("AA", 1000, 90, 74, 60, 92) };
            return arr;
        }
    }
}
