using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManager.Model.Student;

namespace StudentManager.Model
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public string School { get; set; }
        public int StartYear { get; set; }
        public double GPA { get; set; }

        public Student(string studentId, string school, int startYear, double gpa
            , int id, string name, DateTime dateOfBirth, string address, double height, double weight)
            : base(id, name, dateOfBirth, address, height, weight)
        {
            StudentId = studentId;
            School = school;
            StartYear = startYear;
            GPA = gpa;
        }

        public enum hocLuc
        {
            Kem,
            Yeu,
            TrungBinh,
            Kha,
            Gioi,
            XuatSac

        }

        public static string TinhHocLuc(double gpa)
        {
            switch (gpa)
            {
                case < 3:
                    return hocLuc.Kem.ToString();
                case < 5:
                    return hocLuc.Yeu.ToString();
                case < 6.5:
                    return hocLuc.TrungBinh.ToString();
                case < 7.5:
                    return hocLuc.Kha.ToString();
                case < 9:
                    return hocLuc.Gioi.ToString();
                default:
                    return hocLuc.XuatSac.ToString();
            }
        }

    }
}
