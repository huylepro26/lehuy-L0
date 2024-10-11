using StudentManager.Model;
using StudentManager.Validate;
using System;
using System.Collections.Generic;

namespace StudentManager.Controller
{
    public class StudentInput
    {
        Validation validation = new Validation();

        public string GetName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    validation.CheckName(name);
                    return name;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public DateTime GetDOB()
        {
            while (true)
            {
                try
                {
                    Console.Write("DOB (yyyy-MM-dd): ");
                    string input = Console.ReadLine();
                    validation.CheckDateOfBirth(input);
                    return DateTime.Parse(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public string GetAddress()
        {
            while (true)
            {
                try
                {
                    Console.Write("Address: ");
                    string address = Console.ReadLine();
                    validation.CheckAddress(address);
                    return address;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double GetHeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Height (cm): ");
                    string height = Console.ReadLine();
                    validation.CheckHeight(height);
                    return double.Parse(height);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double GetWeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Weight (kg): ");
                    string weight = Console.ReadLine();
                    validation.CheckWeight(weight);
                    return double.Parse(weight);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public string GetStudentId(List<Student> students)
        {
            while (true)
            {
                try
                {
                    Console.Write("StudentID: ");
                    string studentId = Console.ReadLine();
                    validation.CheckStudentId(students, studentId);
                    return studentId;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public string GetSchool()
        {
            while (true)
            {
                try
                {
                    Console.Write("School: ");
                    string school = Console.ReadLine();
                    validation.CheckSchool(school);
                    return school;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public int GetStartYear()
        {
            while (true)
            {
                try
                {
                    Console.Write("Start year: ");
                    string startYear = Console.ReadLine();
                    validation.CheckStartYear(startYear);
                    return int.Parse(startYear);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double GetGPA()
        {
            while (true)
            {
                try
                {
                    Console.Write("GPA: ");
                    string gpa = Console.ReadLine();
                    validation.CheckGPA(gpa);
                    return double.Parse(gpa);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public int GetID()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Id: ");
                    string id = Console.ReadLine();
                    validation.CheckId(id);
                    return int.Parse(id);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public int GetChoice()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();
                    validation.CheckMenuChoice(choice);
                    return int.Parse(choice);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}