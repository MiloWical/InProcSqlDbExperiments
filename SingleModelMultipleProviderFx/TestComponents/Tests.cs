using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponents
{
    using Model;

    public static class Tests
    {
        public const int TestSeeds = 100;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    using (var entities = new IdEntities())
        //    {
        //        entities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

        //        entities.Ids.RemoveRange(entities.Ids);
        //        entities.SaveChanges();

        //        for (var i = 1; i <= TestSeeds; ++i)
        //        {
        //            entities.Ids.Add(new Id { Value = i });
        //        }

        //        entities.SaveChanges();
        //    }
        //}

        //[TestMethod]
        public static int ClearTable()
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

            return recordCount;

            //Assert.AreEqual(0, recordCount);
        }

        //[TestMethod]
        public static int AddRecords(int offsetRecords)
        {
            var recordCount = -1;
            var recordsToInsert = TestSeeds + offsetRecords;

            using (var entities = new IdEntities())
            {

                for (var i = TestSeeds + 1; i <= recordsToInsert; ++i)
                {
                    entities.Ids.Add(new Id { Value = i });
                }

                entities.SaveChanges();

                recordCount = entities.Ids.Count();

            }

            return recordCount;

            //Assert.AreEqual(recordsToInsert, recordCount);
        }

        //[TestMethod]
        public static int UpdateRecord(int testValue)
        {
            
            var actualValue = -1;

            using (var entities = new IdEntities())
            {
                entities.Ids.First().Value = testValue;
                entities.SaveChanges();
            }

            using (var entities = new IdEntities())
            {
                // ReSharper disable PossibleInvalidOperationException
                actualValue = entities.Ids.First().Value.Value;
                // ReSharper restore PossibleInvalidOperationException
            }

            //Assert.AreEqual(testUpdateValue, actualValue);

            return actualValue;
        }

        //[TestMethod]
        public static int RemoveRecords(int recordsToRemove)
        {
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

            return recordCount;

            //Assert.AreEqual(TestSeeds - recordsToRemove, recordCount);
        }
    }
}
