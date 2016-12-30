using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
    class FileChecker
    {
        List<Employee> list;
        public List<Employee> CheckFile(ISerDeser isd, ReaderConfig read)
        {
            if (read.ReadLine().ToLower() == "xml")
            {
                isd = new XmlReadWrite();
                if (File.Exists("employee.xml"))
                {
                   list = (List<Employee>)isd.Deserial();
                }
                else
                {
                    list = new List<Employee>();
                }
            }
            if (read.ReadLine().ToLower() == "bin")
            {
                isd = new BinReadWrite();
                if (File.Exists("employee.dat"))
                {
                    list = (List<Employee>)isd.Deserial();
                }
                else
                {
                    list = new List<Employee>();
                }
            }
            if (read.ReadLine().ToLower() != "xml" && read.ReadLine().ToLower() != "bin")
            {
                Console.WriteLine("Проверьте правильность записи конфигурации формата в файле option.ini. Обратите внимание, что доступны только bin и xml форматы");
            }
            return list;
        }
    }
}
