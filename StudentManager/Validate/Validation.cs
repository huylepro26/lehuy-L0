using StudentManager.Model;
using StudentManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Validate
{
    public class Validation
    {
        public void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Constant.maxLengthName || name.Any(char.IsDigit))
            {
                throw new ArgumentException($"Person name must be < {Constant.maxLengthName} and no digit or null");
            }
        }

        public void CheckId(string number)
        {
            if (int.TryParse(number, out int id))
            {
                if (id <= 0)
                {
                    throw new ArgumentException("ID must be a positive number.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid number.");
            }
        }

        public void CheckDateOfBirth(string input)
        {
            if (DateTime.TryParse(input, out DateTime dateOfBirth))
            {
                if (dateOfBirth.Year < Constant.dateBirthStart)
                {
                    throw new ArgumentException($"Date of birth must be from the year {Constant.dateBirthStart} or later.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid date format. Please use yyyy-MM-dd.");
            }
        }

        public void CheckAddress(string address)
        {
            if (address.Length > Constant.addressLength)
            {
                throw new ArgumentException("Address must be < than 300 characters.");
            }
        }

        public void CheckHeight(string input)
        {
            if (double.TryParse(input, out double height))
            {
                if (height < Constant.minHeight || height > Constant.maxHeight)
                {
                    throw new ArgumentException("Height must be between 50.0 and 300.0 cm.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid number.");
            }
        }

        public void CheckWeight(string input)
        {
            if (double.TryParse(input, out double weight))
            {
                if (weight < Constant.minWeight || weight > Constant.maxWeight)
                {
                    throw new ArgumentException("Weight must be between 5.0 and 1000.0 kg.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid number.");
            }
        }

        public void CheckStudentId(List<Student> students, string studentId)
        {
            bool isDelete = false;
            if (string.IsNullOrEmpty(studentId))
            {
                throw new ArgumentException("Student ID must not be null.");
            }
            else
            {
                if (studentId.Length != Constant.studentIdLength ||
                    !isDelete && students.Any(s => s.StudentId == studentId) ||
                    isDelete && !students.Any(s => s.StudentId == studentId))
                {
                    throw new ArgumentException("Student ID must be exactly 10 characters and not a duplicate.");
                }
            }
        }

        public void CheckSchool(string school)
        {
            if (string.IsNullOrEmpty(school) || school.Length > Constant.schooNameLength)
            {
                throw new ArgumentException("School must be non-empty and less than 200 characters.");
            }
        }

        public void CheckStartYear(string input)
        {
            if (int.TryParse(input, out int startYear))
            {
                if (startYear < Constant.minstartYear || startYear > DateTime.Now.Year)
                {
                    throw new ArgumentException("Start year must be from 1900 to the current year.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid year.");
            }
        }

        public void CheckGPA(string number)
        {
            if (double.TryParse(number, out double gpa))
            {
                if (gpa < 0.0 || gpa > 10.0)
                {
                    throw new ArgumentException("GPA must be between 0.0 and 10.0.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid number.");
            }
        }

        public void CheckMenuChoice(string number)
        {
            if (int.TryParse(number, out int choice))
            {
                if (choice <= 0 || choice > 8)
                {
                    throw new ArgumentException("Choice must be between 1-8.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid format. Please enter a valid number.");
            }
        }
    }
}