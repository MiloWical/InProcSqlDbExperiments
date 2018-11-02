using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlCeTests
{
    using System.Linq;
    using Model;
    using TestComponents;

    [TestClass]
    public class UnitTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            using (var entities = new IdEntities())
            {
                entities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                entities.Ids.RemoveRange(entities.Ids);
                entities.SaveChanges();

                for (var i = 1; i <= Tests.TestSeeds; ++i)
                {
                    entities.Ids.Add(new Id { Value = i });
                }

                entities.SaveChanges();
            }
        }

        [TestMethod]
        public void ClearTableTest()
        {
            var recordCount = Tests.ClearTable();

            Assert.AreEqual(0, recordCount);
        }

        [TestMethod]
        public void AddRecordsTest()
        {
            const int recordsToInsert = 100;

            var recordCount = Tests.AddRecords(recordsToInsert);

            Assert.AreEqual(Tests.TestSeeds + recordsToInsert, recordCount);
        }

        [TestMethod]
        public void UpdateRecordTest()
        {
            var testValue = new Random().Next(500_000, 1_000_000);
            var actualValue = Tests.UpdateRecord(testValue);

            Assert.AreEqual(testValue, actualValue);
        }

        [TestMethod]
        public void RemoveRecordsTest()
        {
            var recordsToRemove = Tests.TestSeeds - new Random().Next(1, Tests.TestSeeds - 1);
            var recordCount = Tests.RemoveRecords(recordsToRemove);

            Assert.AreEqual(Tests.TestSeeds - recordsToRemove, recordCount);
        }
    }
}
