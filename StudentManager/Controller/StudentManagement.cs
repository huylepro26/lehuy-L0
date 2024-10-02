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
        private StudentInput studentInput = new StudentInput();

        public void addStudent()
        {
            Console.WriteLine("Add a new student:");
            string name = studentInput.getName();
            DateTime dateOfBirth = studentInput.getDOB();
            string address = studentInput.getAddress();
            double height = studentInput.getHeight();
            double weight = studentInput.getWeight();
            string studentId = studentInput.getStudentId(students);
            string school = studentInput.getSchool();
            int startYear = studentInput.getStartYear();
            double gpa = studentInput.getGPA();
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

        public Student findStudentById()
        {
            Console.WriteLine("Find a student by ID:");
            int idToFind = studentInput.getID();
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



        public void updateStudent(Student studentFound)
        {

            Student studentToUpdate = studentFound;

            if (studentToUpdate != null)
            {
                studentToUpdate.Name = studentInput.getName();
                studentToUpdate.DateOfBirth = studentInput.getDOB();
                studentToUpdate.Address = studentInput.getAddress();
                studentToUpdate.Weight = studentInput.getWeight();
                studentToUpdate.Height = studentInput.getHeight();
                studentToUpdate.School = studentInput.getSchool();
                studentToUpdate.StartYear = studentInput.getStartYear();
                studentToUpdate.GPA = studentInput.getGPA();
                Console.WriteLine("Update success!");

            }

        }

        public void deleteStudent(Student studentFound)
        {

            Student studentToRemove = studentFound;

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
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