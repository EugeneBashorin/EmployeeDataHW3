using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataHW3
{
   [Serializable]
   public class Employee : Person
    {       
        public Employee() { }
        public Employee(string surname, string firstname, string position) : base(surname, firstname, position)
        {
            Firstname = firstname;
            Surname = surname;
            Position = position;
        }
    }
}
