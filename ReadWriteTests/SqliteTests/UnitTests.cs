namespace SqliteTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTests
    {
        private const int TestSeeds = 100;

        [TestInitialize]
        public void TestInitialize()
        {
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

        [TestMethod]
        public void ClearTable()
        {
            var recordCount = -1;

            using (var entities = new IdEntities())
            {
                entities.Ids.RemoveRange(entities.Ids);
                entities.SaveChanges();
            }

            using (var entities = new IdEntities())
            {
                recordCount = entities.Ids.Count();
            }

            Assert.AreEqual(0, recordCount);
        }

        [TestMethod]
        public void AddRecords()
        {
            var recordCount = -1;
            const int recordsToInsert = TestSeeds + 400;

            using (var entities = new IdEntities())
            {

                for (var i = TestSeeds + 1; i <= recordsToInsert; ++i)
                {
                    entities.Ids.Add(new Id { Value = i });
                }

                entities.SaveChanges();
            }

            using (var entities = new IdEntities())
            {
                recordCount = entities.Ids.Count();
            }

            Assert.AreEqual(recordsToInsert, recordCount);
        }

        [TestMethod]
        public void UpdateRecord()
        {
            var testUpdateValue = new Random().Next(500_000, 1_000_000);
            long actualValue = -1;

            using (var entities = new IdEntities())
            {
                entities.Ids.First().Value = testUpdateValue;
                entities.SaveChanges();
            }

            using (var entities = new IdEntities())
            {
                actualValue = entities.Ids.First().Value;
            }

            Assert.AreEqual(testUpdateValue, actualValue);
        }

        [TestMethod]
        public void RemoveRecords()
        {
            var recordsToRemove = TestSeeds - new Random().Next(1, TestSeeds - 1);
            var recordCount = -1;

            using (var entities = new IdEntities())
            {
                entities.Ids.RemoveRange(entities.Ids.Take(recordsToRemove));
                entities.SaveChanges();
            }

            using (var entities = new IdEntities())
            {
                recordCount = entities.Ids.Count();
            }

            Assert.AreEqual(TestSeeds - recordsToRemove, recordCount);
        }
    }
}
