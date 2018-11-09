namespace NMemory.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;

    [TestClass]
    public class UnitTests
    {
        private const int TestSeeds = 100;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void CallStoredProcedure()
        {
            using (var entities = new IdEntities())
            {
                var result = entities.MaxRoot();
            }
        }
    }
}
