using StudentManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Utils
{
    public class Validation
    {


        public string ValidateName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name) || name.Length > Constant.maxLengthName || name.Any(char.IsDigit))
                    {
                        throw new ArgumentException();
                    }

                    return name;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Name must be non-empty, < than 100 characters," +
                            " and must not contain digits.");
                }
            }
        }

        public int ValidateId()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    if (id <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return id;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("ID must be a positive number.");
                }
            }
        }

        public DateTime ValidateDateOfBirth()
        {
            while (true)
            {
                try
                {
                    Console.Write("DOB (yyyy-MM-dd): ");
                    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                    if (dateOfBirth.Year < Constant.dateBirthStart)
                    {
                        throw new ArgumentException();
                    }

                    return dateOfBirth;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Date of birth must be from the year 1900 or later.");
                }
            }
        }

        public string ValidateAddress()
        {
            while (true)
            {
                try
                {
                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    if (address.Length > Constant.addressLength)
                    {
                        throw new ArgumentException();
                    }

                    return address;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Address must be < than 300 characters.");
                }
            }
        }

        public double ValidateHeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Height (cm): ");
                    double height = double.Parse(Console.ReadLine());

                    if (height < Constant.minHeight || height > Constant.maxHeight)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return height;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Height must be between 50.0 and 300.0 cm.");
                }
            }
        }

        public double ValidateWeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Weight (kg): ");
                    double weight = double.Parse(Console.ReadLine());

                    if (weight < Constant.minWeight || weight > Constant.maxWeight)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return weight;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Weight must be between 5.0 and 1000.0 kg.");
                }
            }
        }

        public string ValidateStudentId(HashSet<string> existingIds, bool isDelete = false)
        {
            while (true)
            {
                try
                {
                    Console.Write("StudentID: ");
                    string studentId = Console.ReadLine();

                    if (studentId.Length != Constant.studentIdLength || (isDelete && !existingIds.Contains(studentId)))
                    {
                        throw new ArgumentException();
                    }

                    if (!isDelete && existingIds.Contains(studentId))
                    {
                        throw new ArgumentException();
                    }

                    return studentId;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Student ID must be exactly 10 characters and not existingId .");
                }
            }
        }

        public string ValidateSchool()
        {
            while (true)
            {
                try
                {
                    Console.Write("School: ");
                    string school = Console.ReadLine();

                    if (string.IsNullOrEmpty(school) || school.Length > Constant.schooNameLength)
                    {
                        throw new ArgumentException();
                    }

                    return school;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("School must be non-empty and < than 200 characters.");
                }
            }
        }

        public int ValidateStartYear()
        {
            while (true)
            {
                try
                {
                    Console.Write("Start year: ");
                    int startYear = int.Parse(Console.ReadLine());

                    if (startYear < Constant.minstartYear || startYear > DateTime.Now.Year)
                    {
                        throw new ArgumentOutOfRangeException(  );
                    }

                    return startYear;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid year.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Start year must be from 1900 to the current year.");
                }
            }
        }

        public double ValidateGPA()
        {
            while (true)
            {
                try
                {
                    Console.Write("GPA: ");
                    double gpa = double.Parse(Console.ReadLine());

                    if (gpa < 0.0 || gpa > 10.0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return gpa;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("GPA must be between 0.0 and 10.0.");
                }
            }
        }
    }
}
