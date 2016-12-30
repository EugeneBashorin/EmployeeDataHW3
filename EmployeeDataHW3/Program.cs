using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
   class Program
    {
           static void Main(string[] args)
        {           
            AddDelFindInf metod = new AddDelFindInf();
            ReaderConfig read = new ReaderConfig();
            FileChecker check = new FileChecker();
            new Menu().Show(metod, read, check);
        }         
    }   
}