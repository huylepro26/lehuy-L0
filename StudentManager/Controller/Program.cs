using StudentManager.Main;
using StudentManager.Model;
using StudentManager.Utils;
using StudentManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Controller
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Validation validation = new Validation();
            StudentManagement student = new StudentManagement();

            while (true)
            {
                Menu.menuScreen();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        student.addStudent();
                        break;
                    case 2:
                        student.findStudentById();
                        break;
                    case 3:
                        student.updateStudent();
                        break;
                    case 4:
                        student.deleteStudent();
                        break;
                    case 5:
                        student.showStudent();
                        break;
                    case 6:
                        student.ShowStatistics();
                        break;
                    case 7:
                        student.ShowListStudentsStatistic();
                        break;
                    case 8:
                        return;

                }
            }
        }
    }
}

