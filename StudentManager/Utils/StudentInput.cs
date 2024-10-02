using StudentManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Utils
{
    public class StudentInput
    {
        Validation validation = new Validation();
        public string getName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    validation.ValidateName(name);
                    return name;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public DateTime getDOB()
        {
            while (true)
            {

                try
                {
                    Console.Write("DOB (yyyy-MM-dd): ");
                    string input = Console.ReadLine();
                    validation.ValidateDateOfBirth(input);
                    return DateTime.Parse(input);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            }
        }

        public string getAddress()
        {
            while (true)
            {
                try
                {
                    Console.Write("Address: ");
                    string address = Console.ReadLine();
                    validation.ValidateAddress(address);

                    return address;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double getHeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Height (cm): ");
                    string height = Console.ReadLine();
                    validation.ValidateHeight(height);
                    return double.Parse(height);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double getWeight()
        {
            while (true)
            {


                try
                {
                    Console.Write("Weight (kg): ");
                    string weight = Console.ReadLine();
                    validation.ValidateWeight(weight);
                    return double.Parse(weight);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }

        public string getStudentId(List<Student> students)
        {
            while (true)
            {

                try
                {
                    Console.Write("StudentID: ");
                    string studentId = Console.ReadLine();
                    validation.ValidateStudentId(students, studentId);
                    return studentId;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }


            }
        }

        public string getSchool()
        {
            while (true)
            {
                try
                {
                    Console.Write("School: ");
                    string school = Console.ReadLine();
                    validation.ValidateSchool(school);


                    return school;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }

        public int getStartYear()
        {
            while (true)
            {

                try
                {
                    Console.Write("Start year: ");
                    string startYear = Console.ReadLine();
                    validation.ValidateStartYear(startYear);
                    return int.Parse(startYear);


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public double getGPA()
        {
            while (true)
            {


                try
                {
                    Console.Write("GPA: ");
                    string gpa = Console.ReadLine();
                    validation.ValidateGPA(gpa);
                    return double.Parse(gpa);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public int getID()
        {
            while (true)
            {

                try
                {
                    Console.Write("Enter Id: ");
                    string ID = Console.ReadLine();
                    validation.ValidateId(ID);
                    return int.Parse(ID);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        public int getChoice()
        {
            while (true)
            {

                try
                {
                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();
                    validation.ValidateMenuChoice(choice);
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
