﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IdEntities : DbContext
    {
        public IdEntities()
            : base("name=IdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Id> Ids { get; set; }
    
        public virtual ObjectResult<Nullable<double>> MaxRoot()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("MaxRoot");
        }
    }
}
