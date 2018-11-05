using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sqlite.Tests
{
    using Model;

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
        [ExpectedException(typeof(System.Data.Entity.Core.EntityCommandCompilationException))]
        //SQLite doesn't support stored procedures.
        public void CallStoredProcedure()
        {
            using (var entities = new IdEntities())
            {
                var result = entities.MaxRoot();
            }
        }
    }
}
