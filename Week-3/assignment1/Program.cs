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

            gradeList.Add(ReadCourse("Enter a course."));


        }

        int ReadInt(string question)
        {
            question = Console.ReadLine();

            return int.Parse(question);
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

        }

        Course ReadCourse(string question)
        {
            Console.WriteLine(question);
            Course course1 = new Course();

            Console.Write("Name of the course: ");
            course1.name = Console.ReadLine();

            Console.Write("Grade for {0}: ", course1.name);
            course1.grade = int.Parse(Console.ReadLine());

            Console.WriteLine("0. None 1. Absent 2. Insufficient 3. Sufficient 4. Good");
            Console.Write("Practical grade for {0}: ", course1.name);
            course1.practical = int.Parse(Console.ReadLine());

            return course1;
        }

        void DisplayCourse(Course course)
        {

        }
    }
}
