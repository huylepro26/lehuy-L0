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
                Console.Write("Enter Id: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    if (id > 0)
                    {
                        return id;
                    }
                    else
                    {
                        Console.WriteLine("ID must be a positive number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
            }
        }


        public DateTime ValidateDateOfBirth()
        {
            while (true)
            {
                Console.Write("DOB (yyyy-MM-dd): ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime dateOfBirth))
                {
                    if (dateOfBirth.Year >= Constant.dateBirthStart)
                    {
                        return dateOfBirth;
                    }
                    else
                    {
                        Console.WriteLine("Date of birth must be from the year 1900 or later.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
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
                Console.Write("Height (cm): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double height))
                {
                    if (height >= Constant.minHeight && height <= Constant.maxHeight)
                    {
                        return height;
                    }
                    else
                    {
                        Console.WriteLine("Height must be between 50.0 and 300.0 cm.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
            }
        }
        public double ValidateWeight()
        {
            while (true)
            {
                Console.Write("Weight (kg): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double weight))
                {
                    if (weight >= Constant.minWeight && weight <= Constant.maxWeight)
                    {
                        return weight;
                    }
                    else
                    {
                        Console.WriteLine("Weight must be between 5.0 and 1000.0 kg.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
            }
        }

        public string ValidateStudentId(List<Student> students, bool isDelete = false)
        {
            while (true)
            {
                Console.Write("StudentID: ");
                string studentId = Console.ReadLine();

                // Kiểm tra độ dài của Student ID và tính hợp lệ
                if (studentId.Length != Constant.studentIdLength ||
                    (!isDelete && students.Any(s => s.StudentId == studentId)) ||
                    (isDelete && !students.Any(s => s.StudentId == studentId)))
                {
                    Console.WriteLine("Student ID must be exactly 10 characters and unique.");
                    continue; // Quay lại vòng lặp nếu kiểm tra không hợp lệ
                }

                return studentId; // Trả về ID hợp lệ
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
                Console.Write("Start year: ");
                string input = Console.ReadLine();


                if (int.TryParse(input, out int startYear))
                {
                    if (startYear >= Constant.minstartYear && startYear <= DateTime.Now.Year)
                    {
                        return startYear;
                    }
                    else
                    {
                        Console.WriteLine("Start year must be from 1900 to the current year.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter a valid year.");
                }
            }
        }

        public double ValidateGPA()
        {
            while (true)
            {
                Console.Write("GPA: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double gpa))
                {
                    if (gpa >= 0.0 && gpa <= 10.0)
                    {
                        return gpa;
                    }
                    else
                    {
                        Console.WriteLine("GPA must be between 0.0 and 10.0.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter a valid number.");
                }
            }
        }
    }
}
