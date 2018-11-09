using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalDb.Tests
{
    using System.Linq;
    using Model;

    [TestClass]
    public class UnitTests
    {
        private const int TestSeeds = 100;

        [TestInitialize]
        public void TestInitialize()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            using (var entities = new IdEntities())
            {
                entities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                entities.Ids.RemoveRange(entities.Ids);
                entities.SaveChanges();

                for (var i = 1; i <= TestSeeds; ++i)
                {
                    entities.Ids.Add(new Id { Value = i });
                }

                entities.SaveChanges();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            using (var entities = new IdEntities())
            {
                if (entities.Database.Exists())
                    entities.Database.Delete();
            }
        }

        [TestMethod]
        public void CallStoredProcedure()
        {
            double result;

            using (var entities = new IdEntities())
            {
                result = entities.MaxRoot().FirstOrDefault().GetValueOrDefault();
            }

            Assert.AreEqual(Math.Sqrt(TestSeeds), result);
        }
    }
}
