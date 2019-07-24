using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("János", new DateTime(1826, 03, 11), Gender.Male);
            string str = person.ToString();
            
            Console.WriteLine(Fetch(person.ToString(), "Gender"));
            Console.Read();
        }

        static string Fetch(string str, string key)
        {
            Match m = Regex.Match(str, key + "[^,]*");
            string[] s = m.ToString().Split(':');
            return s[1].Trim();
        }
    }
}
