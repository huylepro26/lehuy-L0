using StudentManager.Controller;
using StudentManager.Model;
using StudentManager.Validate;
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
        private StudentInput studentInput = new StudentInput();

        public void AddStudent()
        {
            Console.WriteLine("Add a new student:");
            string name = studentInput.GetName();
            DateTime dateOfBirth = studentInput.GetDOB();
            string address = studentInput.GetAddress();
            double height = studentInput.GetHeight();
            double weight = studentInput.GetWeight();
            string studentId = studentInput.GetStudentId(students);
            string school = studentInput.GetSchool();
            int startYear = studentInput.GetStartYear();
            double gpa = studentInput.GetGPA();
            int id = CreateId();

            Student student = new Student(studentId, school, startYear, gpa, id, name, dateOfBirth, address, height, weight);
            students.Add(student);

            Console.WriteLine("Student added successfully!");
        }

        private int CreateId()
        {
            return nextId++;
        }

        public void ShowStudent()
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

        public Student FindStudentById()
        {
            Console.WriteLine("Find a student by ID:");
            int idToFind = studentInput.GetID();
            Student student = students.FirstOrDefault(s => s.Id == idToFind);

            if (student != null)
            {
                Console.WriteLine("Student found:");
                Console.WriteLine($"{student.Id} {student.Name} {student.DateOfBirth:yyyy-MM-dd} {student.Address} {student.Height} {student.Weight} {student.StudentId} {student.School} {student.StartYear} {student.GPA}");
                return student;
            }
            else
            {
                Console.WriteLine("Student not found.");
                return null;
            }
        }

        public void UpdateStudent(Student studentFound)
        {
            if (studentFound != null)
            {
                studentFound.Name = studentInput.GetName();
                studentFound.DateOfBirth = studentInput.GetDOB();
                studentFound.Address = studentInput.GetAddress();
                studentFound.Weight = studentInput.GetWeight();
                studentFound.Height = studentInput.GetHeight();
                studentFound.School = studentInput.GetSchool();
                studentFound.StartYear = studentInput.GetStartYear();
                studentFound.GPA = studentInput.GetGPA();

                Console.WriteLine("Update success!");
            }
        }

        public void DeleteStudent(Student studentFound)
        {
            if (studentFound != null)
            {
                students.Remove(studentFound);
                Console.WriteLine("Student deleted successfully!");
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

            Console.WriteLine("hoc luc cua cac sinh vien:");
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

            Console.WriteLine("danh sach sinh vien :");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"ten: {student.Name}, hoc luc: {Student.TinhHocLuc(student.GPA)}");
            }
        }
    }
}