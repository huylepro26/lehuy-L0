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
            string studentId = validation.ValidateStudentId(students);
            string school = validation.ValidateSchool();
            int startYear = validation.ValidateStartYear();
            double gpa = validation.ValidateGPA();
            int id = CreateId();
            Student student = new Student(studentId, school, startYear, gpa, id, name, dateOfBirth, address, height, weight);
            students.Add(student);

            Console.WriteLine("Student added successfully!");
        }

        private int CreateId()
        {
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
                studentToUpdate.Name = validation.ValidateName();
                studentToUpdate.DateOfBirth = validation.ValidateDateOfBirth();
                studentToUpdate.Address = validation.ValidateAddress();
                studentToUpdate.Weight = validation.ValidateWeight();
                studentToUpdate.Height = validation.ValidateHeight();
                studentToUpdate.School = validation.ValidateSchool();
                studentToUpdate.StartYear = validation.ValidateStartYear();
                studentToUpdate.GPA = validation.ValidateGPA();
                Console.WriteLine("Update success!");

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

            Console.WriteLine("hoc luc cac sinh vien:");
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

            Console.WriteLine("danh sach cac sinh vien :");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"ten: {student.Name}, hoc luc: {Student.TinhHocLuc(student.GPA)}");
            }
        }
    }
}