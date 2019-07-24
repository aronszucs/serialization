using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System.IO;

namespace SerializationTest
{
    [TestClass]
    public class PersonTest
    {

        [TestMethod]
        public void TestPersonSerialization()
        {
            string path = "persontest";
            Person p1 = Instantiate();
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

        public void TestPersonStringify()
        {

        }
        private Person Instantiate()
        {
            string name = "Test";
            DateTime birth = new DateTime(2012, 01, 01);
            Gender gender = Gender.Female;
            return new Person(name, birth, gender);
        }
    }
}
