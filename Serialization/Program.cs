using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "janos.prs";
            Person person = new Person("János", new DateTime(1826, 03, 11), Gender.Male);
            person.Serialize(path);
            Person newPerson = Person.Deserialize(path);
            
            Console.Read();
        }
    }
}
