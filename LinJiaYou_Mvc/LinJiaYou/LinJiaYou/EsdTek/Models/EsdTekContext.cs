using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EsdTek.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class EsdTekContext : DbContext
    {
        public virtual DbSet<Device> Devices { get; set; }
        public EsdTekContext()
            : base("name=EsdTekContext")
        {

        }
        public EsdTekContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Device>().MapToStoredProcedures();
        }
    }
}