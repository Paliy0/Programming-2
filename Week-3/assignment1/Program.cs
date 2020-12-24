using System;
using System.Collections.Generic;

namespace assignment1
{
    class Program
    {
        class Course
        {
            public string name;
            public int grade;
            public int practical;
            public bool Passed;
            public bool CumLaude;
        }

        public enum PracticalGrade { None, Absent, Insufficient, Sufficient, Good }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<Course> gradeList = new List<Course>();

            for (int i = 0; i < 3; i++)
            {
                ReadCourse("Enter a course.");
                gradeList.Add(new Course());
            }
            DisplayGradeList(gradeList);

            


        }

        int ReadInt(string question)
        {
            Console.Write(question);

            return int.Parse(question);
        }

        string ReadString(string question)
        {
            Console.Write(question);

            return question;
        }

        void DisplayGradeList(List<Course> gradeList)
        {
            
        }

        PracticalGrade ReadPracticalGrade(string question)
        {
            Console.Write(question);
            question = Console.ReadLine();

            if (question == "0")
            {
                return PracticalGrade.None;
            }
            else if (question == "1")
            {
                return PracticalGrade.Absent;
            }
            else if (question == "2")
            {
                return PracticalGrade.Insufficient;
            }
            else if (question == "3")
            {
                return PracticalGrade.Sufficient;
            }
            return PracticalGrade.Good;
        }

        void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.WriteLine("Practical Grade for {0}", practical);
        }

        Course ReadCourse(string question)
        {
            Console.WriteLine(question);
            Course course1 = new Course();

            course1.name = ReadString("Name of the course: ");

            course1.grade = ReadInt($"Grade for {course1.name}");

            Console.WriteLine("0. None 1. Absent 2. Insufficient 3. Sufficient 4. Good");
            ReadPracticalGrade($"Practical grade for {course1.name}");

            return course1;
        }

        void DisplayCourse(Course course)
        {

        }
    }
}
