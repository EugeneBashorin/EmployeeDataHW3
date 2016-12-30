using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataHW3
{
    [Serializable]
    public abstract class Person
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public Person() { }
        public Person(string surname, string firstname, string position)
        {
            Firstname = firstname;
            Surname = surname;
            Position = position;
        }
        public override string ToString()
        {
            return Surname + " " + Firstname + " " + Position;
        }
    }
}
