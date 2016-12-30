using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataHW3
{
   public class AddDelFindInf
    {
        public List<Employee> Employees { get; set; }

        public void AddEmp(string surname, string firstname, string post)
        {
            Employees.Add(new Employee(surname, firstname, post));
        }

        public void Del(string surname)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Surname == surname)
                {
                    Employees.Remove(Employees[i]);
                }
            }
        }

        public string GetInfo(List<Employee> listInfo)
        {
            string info = "";
            for (int i = 0; i < listInfo.Count; i++)
            {
                string ind = (i + 1).ToString();
                string firstname = listInfo[i].Firstname;
                string surname = listInfo[i].Surname;
                string position = listInfo[i].Position;
                string str = $"{ind} {surname} {firstname} {position}";
                info += str + "\n";
            }
            return info;
        }

        public Employee FindEmployeeSurname(string surname)
        {
            Employee find = Employees.Find(x => x.Surname == surname);
            return find;
        }

        public Employee FindEmployeeFirstname(string firstname)
        {
            Employee find = Employees.Find(x => x.Firstname == firstname);
            return find;
        }

        public Employee FindEmployeePost(string post)
        {
            Employee find = Employees.Find(x => x.Position == post);
            return find;
        }
    }
}
