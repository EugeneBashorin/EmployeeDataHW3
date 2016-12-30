using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
    class ReaderConfig
    {
        public string ReadLine()
        {
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader("option.ini", System.Text.Encoding.Default))
                {
                    line = sr.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл необходимой конфигурации не найден.\nСоздайте файл option.ini, запишите в него необходимую конфиг. bin или xml ");
            }
            return line;
        }
    }
}
