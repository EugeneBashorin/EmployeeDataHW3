using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
    public class XmlReadWrite : ISerDeser
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
        public void Serial(object data)
        {
            using (FileStream fs = new FileStream("employee.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, data);
            }
        }
        public object Deserial()
        {
            using (FileStream fs = new FileStream("employee.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return new object();
                }
                return xs.Deserialize(fs) ?? new object();
            }
        }
    }
}