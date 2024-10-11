using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        private static int nextId = 1;
        public Person()
        {
            Id = nextId++;
        }

        public Person(int id, string name, DateTime dateOfBirth, string address, double height, double weight)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }
    }
}
