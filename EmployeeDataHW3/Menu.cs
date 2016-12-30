using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
    class Menu
    { 
        public ISerDeser Isd { get; set; }
       
        public void Show(AddDelFindInf metod, ReaderConfig read, FileChecker check)
        {
            Console.WriteLine("Считывание конфигурации из файла option.ini, нажмите Enter.");
            read.ReadLine();
            Console.ReadLine();
            Console.WriteLine("Считывание базы сотрудников, нажмите Enter.");
            metod.Employees = check.CheckFile(Isd, read);
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Нажмите Enter для просмотра всех доступных команд либо введите команду:");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "add":
                        string surname;
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите фамилию: ");
                            surname = Console.ReadLine();
                            if (surname.Length > 25)
                            {
                                Console.WriteLine("Некорректный ввод фамилии, максимальная длина фамилии 25 символов.");
                                Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        }
                        string firstname;
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя сотрудника : ");
                            firstname = Console.ReadLine();
                            if (firstname.Length > 15)
                            {
                                Console.WriteLine("Некорректный ввод имени, максимальная длина имени 15 символов.");
                                Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        }
                        string position;
                        while (true)
                        {
                         Console.Clear();
                         Console.WriteLine("Введите должность сотрудника: ");
                         position = Console.ReadLine();
                            if (position.Length > 20)
                            {
                                Console.WriteLine("Некорректный ввод наименования должности, максимальная длина наименования должности 20 символов.");
                                Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }                           
                        }
                        metod.AddEmp(surname, firstname, position);
                        Console.WriteLine("Сотрудник " + surname + " " + firstname + " " + position + " успешно добавлен в базу данных.");
                        Console.ReadLine();
                        break;

                    case "del":
                            while (true)
                        {
                         Console.Clear();
                         Console.WriteLine("Введите фамилию удаляемого сотрудника: ");
                            surname = Console.ReadLine();
                                if (metod.Employees.Exists(a => a.Surname == surname))
                                {
                          metod.Del(surname);
                          Console.WriteLine("Сотрудник с фамилией " + surname + " удален");
                          }
                          else
                          {
                           Console.WriteLine("Такой фамилии нет в списке");
                           }
                            Console.ReadLine();
                            break;
                        }
                        break;
                        case "inf":
                        Console.WriteLine(metod.GetInfo(metod.Employees));
                        Console.ReadLine();
                        break;
                    case "findsur":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите фамилию сотрудника: ");
                            surname = Console.ReadLine();
                            if (metod.Employees.Exists(a => a.Surname == surname))
                            {
                                Console.WriteLine(metod.FindEmployeeSurname(surname).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Фамилии " + surname + " нет в списке.");
                            }
                            Console.ReadLine();
                            break;
                        }
                        break;
                    case "findnam":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя сотрудника: ");
                            firstname = Console.ReadLine();
                            if (metod.Employees.Exists(a => a.Firstname == firstname))
                            {
                                Console.WriteLine(metod.FindEmployeeFirstname(firstname).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Имени " + firstname + " нет в списке.");
                            }
                            Console.ReadLine();
                            break;
                        }
                        break;
                    case "findpos":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите должность сотрудника: ");
                            position = Console.ReadLine();
                            if (metod.Employees.Exists(a => a.Position == position))
                            {
                                Console.WriteLine(metod.FindEmployeePost(position).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Сотрудников с должностью " + position+" нет в списке.");
                            }
                            Console.ReadLine();
                            break;
                        }
                        break;
                    case "exit":
                        if (read.ReadLine().ToLower() == "xml")
                        {
                           Isd = new XmlReadWrite();
                        }
                        if (read.ReadLine().ToLower() == "bin")
                        {
                            Isd = new BinReadWrite();    
                        }
                            Isd.Serial(metod.Employees);
                        return;
                }
                if (command.ToLower() != "add" && command.ToLower() != "del" && command.ToLower() != "inf" && command.ToLower() != "findsur" && command.ToLower() != "findnam" && command.ToLower() != "findpos" && command.ToLower() != "exit")
                {
                    Help();
                }
            }
        }
        public void Help()
        {
            Console.WriteLine("Командное меню:");
            Console.WriteLine("\tadd добавить сотрудника");
            Console.WriteLine("\tdel удалить сотрудника по фамилии");
            Console.WriteLine("\tinf просмотреть инфу о всех сотрудниках");
            Console.WriteLine("\tfindsur найти сотрудника по фамилии");
            Console.WriteLine("\tfindnam найти сотрудника по фамилии");
            Console.WriteLine("\tfindpos найти сотрудника по фамилии");
            Console.WriteLine("\texit выход");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
