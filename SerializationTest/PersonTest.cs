using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System.IO;
using System.Text.RegularExpressions;


namespace SerializationTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestPersonSerialization()
        {
            string path = "persontest";
            Person p1 = GetPersonInstance();
            try
            {
                p1.Serialize(path);
                Person p2 = Person.Deserialize(path);
                Assert.AreEqual(p1.Name, p2.Name);
                Assert.AreEqual(p1.BirthDate, p2.BirthDate);
                Assert.AreEqual(p1.Age, p2.Age);
                Assert.AreEqual(p1.Age, p2.Age);
            }
            catch (AssertFailedException e)
            {
                throw e;
            }
            finally
            {
                FileInfo f = new FileInfo(path);
                f.Delete();
            }
        }

        [TestMethod]
        public void TestPersonStringify()
        {
            Person p = GetPersonInstance();
            string str = p.ToString();
            string name = FetchStrData(str, "Name");
            string genderStr = FetchStrData(str, "Gender");
            Gender gender;
            if (genderStr.Equals("Male"))
            {
                gender = Gender.Male;
            }
            else if (genderStr.Equals("Female"))
            {
                gender = Gender.Female;
            }
            else
            {
                throw new AssertFailedException("Wrong gender");
            }
            int age = int.Parse( FetchStrData(str, "Age"));

            Assert.AreEqual(p.Name, name);
            Assert.AreEqual(p.Age, age);
            Assert.AreEqual(p.Gender, gender);
        }

        private Person GetPersonInstance()
        {
            string name = "Test";
            DateTime birth = new DateTime(2012, 01, 01);
            Gender gender = Gender.Female;
            return new Person(name, birth, gender);
        }

        private string FetchStrData(string str, string key)
        {
            Match m = Regex.Match(str, key + "[^,]*");
            string[] s = m.ToString().Split(':');
            return s[1].Trim();
        }
    }
}
