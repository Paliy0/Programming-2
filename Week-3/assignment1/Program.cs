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
            public PracticalGrade practical;

            public bool Passed()
            {
                if (grade >= 55 && (practical == PracticalGrade.Good || practical == PracticalGrade.Sufficient)) return true;
                return false;
            }

            public bool CumLaude()
            {
                if (practical == PracticalGrade.Good && grade >= 80) return true;
                return false;
            }
        }

        public enum PracticalGrade { None, Absent, Insufficient, Sufficient, Good }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int nrOfCourses = 3;

            List<Course> gradeList = ReadGradeList(nrOfCourses);

            DisplayGradeList(gradeList);
        }

        Course ReadCourse(string question)
        {
            Console.WriteLine(question);
            Course course1 = new Course();

            course1.name = ReadString("Name of the course: ");

            course1.grade = ReadInt($"Grade for {course1.name}: ");

            Console.WriteLine("0. None 1. Absent 2. Insufficient 3. Sufficient 4. Good");
             course1.practical = ReadPracticalGrade($"Practical grade for {course1.name}: ");

            return course1;
        }

        void DisplayCourse(Course course)
        {
            Console.Write($"{course.name} : {course.grade} ");
            DisplayPracticalGrade(course.practical);
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
            Console.WriteLine(practical);
        }

        List<Course> ReadGradeList(int nrOfCourses)
        {
            List<Course> gradeList = new List<Course>();
            for (int i = 0; i < nrOfCourses; i++)
            {
                gradeList.Add(ReadCourse("Enter a course."));
                Console.WriteLine();
            }
            return gradeList;
        }

        void DisplayGradeList(List<Course> gradeList)
        {
            int NrOfRetakes = 0;
            bool cumLaude = false;

            for (int i = 0; i < gradeList.Count; i++)
            {
                DisplayCourse(gradeList[i]);

                if (!gradeList[i].Passed())
                {
                    NrOfRetakes++;
                }
                if(gradeList[i].CumLaude())
                {
                    cumLaude = true;
                }
            }
            if (NrOfRetakes > 0)
            {
                Console.WriteLine($"Too bad, you did not graduate, you got {NrOfRetakes} retakes.");
            }
            else if (!cumLaude)
            {
                Console.WriteLine($"Congratulations, you graduated!");
            }
            else
            {
                Console.WriteLine("Congratulations, you graduated Cum Laude!");
            }
        }

        int ReadInt(string question)
        {
            Console.Write(question);

            string input = Console.ReadLine();
            int grade = int.Parse(input);
            return grade;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            string name = input;
            return name;
        }
    }
}
