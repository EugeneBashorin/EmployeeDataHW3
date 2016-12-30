using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
  public class BinReadWrite : ISerDeser
    {
        BinaryFormatter bf = new BinaryFormatter();
        public void Serial(object data)
        {
            using (FileStream fs = new FileStream("employee.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, data);
            }
        }
        public object Deserial()
        {
            List<Employee> newEmployees = new List<Employee>();
            using (FileStream fs = new FileStream("employee.dat", FileMode.Open))
            {
                if (fs.Length == 0)
                {
                    return new object();
                }
                return bf.Deserialize(fs) ?? new object();
            }
        }

    }
}
