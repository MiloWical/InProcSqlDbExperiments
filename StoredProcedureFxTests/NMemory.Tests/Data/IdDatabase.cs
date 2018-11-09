namespace NMemory.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Tables;

    public class IdDatabase : Database
    {
        public ITable<Id> Ids { get; private set; }

        public Database()
        {
            this.StoredProcedures.Create(new List<double>().AsQueryable());
        }
    }
}
