using StudentManager.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManager.Utils
{
    public class Validation
    {


        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Constant.maxLengthName || name.Any(char.IsDigit))
            {
                throw new ArgumentException($"Person name must be < {Constant.maxLengthName} and no digit or null");
            }
        }


        public void ValidateId(string number)
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

                throw new ArgumentException("Invalid format. Please enter valid number");
            }

        }


        public void ValidateDateOfBirth(string input)
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

        public void ValidateAddress(string address)
        {

            if (address.Length > Constant.addressLength)
            {
                throw new ArgumentException("Address must be < than 300 characters.");
            }



        }

        public void ValidateHeight(string input)
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

        public void ValidateWeight(string input)
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

        public void ValidateStudentId(List<Student> students, string studentId)
        {
            bool isDelete = false;
            if (string.IsNullOrEmpty(studentId))
            {

                throw new ArgumentException("Student ID not null.");

            }
            else
            {
                if (studentId.Length != Constant.studentIdLength || string.IsNullOrEmpty(studentId) ||
                    (!isDelete && students.Any(s => s.StudentId == studentId)) ||
                    (isDelete && !students.Any(s => s.StudentId == studentId)))
                {
                    throw new ArgumentException("Student ID must be exactly 10 characters and not duplicate.");

                }

            }

        }

        public void ValidateSchool(string school)
        {
            if (string.IsNullOrEmpty(school) || school.Length > Constant.schooNameLength)
            {
                throw new ArgumentException("School must be non-empty and < than 200 characters.");
            }



        }

        public void ValidateStartYear(string input)
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

        public void ValidateGPA(string number)
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

                throw new ArgumentException("Invalid format.Please enter a valid number.");
            }

        }

        public void ValidateMenuChoice(string number)
        {

            if (int.TryParse(number, out int choice))
            {
                if (choice <= 0 || choice > 8)
                {
                    throw new ArgumentException("choice must be between 1-9");
                }

            }
            else
            {

                throw new ArgumentException("Invalid format. Please enter valid number");
            }

        }
    }
}
