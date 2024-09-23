using StudentManager.Model;
using StudentManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Main
{
    public class StudentManagement
    {
        private List<Student> students = new List<Student>();
        private HashSet<string> studentIds = new HashSet<string>();
        private int nextId = 1;
        private Validation validation = new Validation();

        public void addStudent()
        {
            Console.WriteLine("Add a new student:");
            string name = validation.ValidateName();
            DateTime dateOfBirth = validation.ValidateDateOfBirth();
            string address = validation.ValidateAddress();
            double height = validation.ValidateHeight();
            double weight = validation.ValidateWeight();
            string studentId = validation.ValidateStudentId(studentIds);
            string school = validation.ValidateSchool();
            int startYear = validation.ValidateStartYear();
            double gpa = validation.ValidateGPA();
            int id = createId();
            Student student = new Student(studentId, school, startYear, gpa, id, name, dateOfBirth, address, height, weight);
            students.Add(student);
            studentIds.Add(studentId);

            Console.WriteLine("Student added successfully!");
        }

        private int createId()
        {
            while (students.Any(s => s.Id == nextId))
            {
                nextId++;
            }
            return nextId++;
        }

        public void showStudent()
        {
            Console.WriteLine("List of students:");
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.DateOfBirth:yyyy-MM-dd} {student.Address} {student.Height} {student.Weight} {student.StudentId} {student.School} {student.StartYear} {student.GPA}");
            }
        }

        public void findStudentById()
        {
            Console.WriteLine("Find a student by ID:");
            int idToFind = validation.ValidateId();
            Student student = students.FirstOrDefault(s => s.Id == idToFind);

            if (student != null)
            {
                Console.WriteLine("Student found:");
                Console.WriteLine($"{student.Id} {student.Name} {student.DateOfBirth:yyyy-MM-dd} {student.Address} {student.Height} {student.Weight} {student.StudentId} {student.School} {student.StartYear} {student.GPA}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void updateStudent()
        {
            Console.WriteLine("Update student information:");
            int idToUpdate = validation.ValidateId();
            Student studentToUpdate = students.FirstOrDefault(s => s.Id == idToUpdate);

            if (studentToUpdate != null)
            {
                Console.WriteLine("Updating student information. Press enter to skip a field.");

                Console.WriteLine(" Enter new name:");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) studentToUpdate.Name = newName;

                Console.WriteLine(" Enter new DOB (yyyy-MM-dd):");

                string newDobInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDobInput))
                {
                    DateTime newDob;
                    if (DateTime.TryParse(newDobInput, out newDob))
                        studentToUpdate.DateOfBirth = newDob;
                }

                Console.WriteLine(" Enter new address:");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAddress)) studentToUpdate.Address = newAddress;

                Console.WriteLine(" Enter new height (cm):");
                string newHeightInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newHeightInput))
                {
                    double newHeight;
                    if (double.TryParse(newHeightInput, out newHeight))
                        studentToUpdate.Height = newHeight;
                }

                Console.WriteLine(" Enter new weight (kg):");
                string newWeightInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newWeightInput))
                {
                    double newWeight;
                    if (double.TryParse(newWeightInput, out newWeight))
                        studentToUpdate.Weight = newWeight;
                }

                Console.WriteLine(" Enter new GPA:");
                string newGpaInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGpaInput))
                {
                    double newGpa;
                    if (double.TryParse(newGpaInput, out newGpa))
                        studentToUpdate.GPA = newGpa;
                }

                Console.WriteLine(" Enter new school:");
                string newSchool = Console.ReadLine();
                if (!string.IsNullOrEmpty(newSchool)) studentToUpdate.School = newSchool;

                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void deleteStudent()
        {
            Console.WriteLine("Deleting a student:");
            int idToDelete = validation.ValidateId();
            Student studentToRemove = students.FirstOrDefault(s => s.Id == idToDelete);

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                studentIds.Remove(studentToRemove.StudentId);

                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void ShowStatistics()
        {
            var statistics = students.GroupBy(s => Student.TinhHocLuc(s.GPA))
                                     .Select(g => new
                                     {
                                         HocLuc = g.Key,
                                         SoLuong = g.Count()
                                     });

            Console.WriteLine("thong ke hoc luc sinh vien:");
            foreach (var stat in statistics)
            {
                Console.WriteLine($"hoc luc: {stat.HocLuc}, so luong: {stat.SoLuong}");
            }
        }

        public void ShowListStudentsStatistic()
        {
            var sortedStudents = students.OrderByDescending(s => s.GPA)
                                         .ThenBy(s => s.Name)
                                         .ToList();

            Console.WriteLine("danh sach sinh vien theo hoc luc:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"ten: {student.Name}, hoc luc: {Student.TinhHocLuc(student.GPA)}");
            }
        }

    }
}