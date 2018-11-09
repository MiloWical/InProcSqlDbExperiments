namespace MockedDbContext.Tests
{
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using Model;
    public class IdEntitiesMock : IdEntities
    {
        public override DbSet<Id> Ids { get => base.Ids; set => base.Ids = value; }

        public override ObjectResult<double?> MaxRoot()
        {
            return base.MaxRoot();
        }
    }
}
