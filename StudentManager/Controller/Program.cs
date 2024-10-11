using StudentManager.Main;
using StudentManager.Model;
using StudentManager.Validate;
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
                int choice = studentInput.GetChoice();

                switch (choice)
                {
                    case 1:
                        student.AddStudent();
                        break;
                    case 2:
                        student.FindStudentById();
                        break;
                    case 3:
                         studentFound = student.FindStudentById();
                        student.UpdateStudent(studentFound);
                        break;
                    case 4:
                         studentFound = student.FindStudentById();
                        student.DeleteStudent(studentFound);
                        break;
                    case 5:
                        student.ShowStudent();
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

