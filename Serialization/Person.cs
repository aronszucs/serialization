using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;


namespace Serialization
{
    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        
        public Person(String name, DateTime birthDate, Gender gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }
        
        protected Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string) info.GetValue("Name", typeof(string));
            BirthDate = (DateTime)info.GetValue("BirthDate", typeof(DateTime));
            Gender = (Gender)info.GetValue("Gender", typeof(Gender));

        }

        public Person() { }

        public string Name
        {
            get; protected set;
        }

        public DateTime BirthDate
        {
            get; protected set;
        }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }

        public Gender Gender
        {
            get; protected set;
        }

        public override String ToString()
        {
            return String.Format("Name: {0}, Age: {1}, Gender: {2}", Name, Age, Gender);
        }

        public void Serialize(string outputPath)
        {
            using (FileStream file = File.Create(outputPath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Person person = new Person(Name, BirthDate, Gender);
                bf.Serialize(file, person);
            }
        }
        
        public static Person Deserialize(string inputPath)
        {
            using (FileStream stream = File.Open(inputPath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (Person)bf.Deserialize(stream);
            }
        }

        public void OnDeserialization(Object obj)
        {
            // Age is a property. It is automatically calculated
            Console.WriteLine("Person deserialized: \n" + this);
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context) 
        {
            info.AddValue("Name", Name);
            info.AddValue("BirthDate", BirthDate);
            info.AddValue("Gender", Gender);
        }
    }
    
}
