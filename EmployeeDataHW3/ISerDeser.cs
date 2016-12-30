using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EmployeeDataHW3
{
   public interface ISerDeser
    {
        void Serial(object data);
        object Deserial();
    }
}
