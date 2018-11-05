using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sqlite.Tests
{
    using System.Text;
    using Model;

    [TestClass]
    public class UnitTests
    {
        const string LoremIpsum =
            "lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua";

        [TestInitialize]
        public void TestInitialize()
        {
            

            using (var entities = new PersonEntities())
            {
                entities.People.RemoveRange(entities.People);
                entities.SaveChanges();

                var tokens = LoremIpsum.Split(' ');

                foreach (var token in tokens)
                {
                    entities.People.Add(new Person
                    {
                        Name = token,
                        PersonId = Guid.NewGuid()
                    });
                }

                entities.SaveChanges();
            }
        }

        [TestMethod]
        public void ReadNames()
        {
            var buffer = new StringBuilder();

            using (var entities = new PersonEntities())
            {
                foreach (var person in entities.People)
                {
                    buffer.Append(person.Name + ' ');
                }
            }

            Assert.AreEqual(LoremIpsum, buffer.ToString().Trim(' '));
        }
    }
}
