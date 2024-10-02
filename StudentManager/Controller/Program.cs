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
            StudentInput studentInput = new StudentInput();
            Student studentFound ;

            while (true)
            {
                Menu.menuScreen();
                int choice = studentInput.getChoice();

                switch (choice)
                {
                    case 1:
                        student.addStudent();
                        break;
                    case 2:
                        student.findStudentById();
                        break;
                    case 3:
                         studentFound = student.findStudentById();
                        student.updateStudent(studentFound);
                        break;
                    case 4:
                         studentFound = student.findStudentById();
                        student.deleteStudent(studentFound);
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

