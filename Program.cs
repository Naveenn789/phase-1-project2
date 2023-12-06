using System;
using System.Collections.Generic;
using System.IO;

namespace ConAppProject_2
{
    internal class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = @"C:\Mphasis\PhaseProjects\ConAppProject-2\ConAppProject-2\teacher.txt";
        static void AddTeacher()
        {
            Teacher newTeacher = new Teacher();

            Console.Write("Enter ID: ");
            newTeacher.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            newTeacher.Name = Console.ReadLine();

            Console.Write("Enter Class: ");
            newTeacher.Class = Console.ReadLine();

            Console.Write("Enter Section: ");
            newTeacher.Section = Console.ReadLine();

            teachers.Add(newTeacher);
            Console.WriteLine("Teacher added successfully.");
        }
        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(values[0]),
                        Name = values[1],
                        Class = values[2],
                        Section = values[3]
                    };

                    teachers.Add(teacher);
                }
            }
        }

        static void SaveData()
        {
            List<string> lines = new List<string>();

            foreach (var teacher in teachers)
            {
                lines.Add(teacher.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }
        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher Data:");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.ID} - {teacher.Name}, {teacher.Class}, {teacher.Section}");
            }
        }
        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter updated Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter updated Class: ");
                teacherToUpdate.Class = Console.ReadLine();

                Console.Write("Enter updated Section: ");
                teacherToUpdate.Section = Console.ReadLine();

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }



        }

        static void Main(string[] args)
        {
            LoadData();
            string op;
            do
            {
                Console.WriteLine("Choose Operation you want to perform \n1. Add Teacher\n2. Update Teacher\n3. Display All Teachers");
                int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddTeacher();
                            break;

                        case 2:
                            UpdateTeacher();
                            break;

                        case 3:
                            DisplayTeachers();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                Console.WriteLine("Do you want to perform the operations again ? yes/no");
                op = Console.ReadLine();
            } while (op=="yes");
            Console.ReadKey();
        }
        
    }
}
