using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Views
{
    public class Menu
    {
        public static void menuScreen()
        {
            Console.WriteLine();
            Console.WriteLine("=====Student Management=====");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Find student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Show student");
            Console.WriteLine("6. Show statistic student");
            Console.WriteLine("7. Show student list by statistic");
            Console.WriteLine("8. Exit");

        }
    }
}
