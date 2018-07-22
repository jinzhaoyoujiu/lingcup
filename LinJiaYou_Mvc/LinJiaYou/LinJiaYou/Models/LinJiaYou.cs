namespace LinJiaYou.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LinJiaYou : DbContext
    {
        public LinJiaYou()
            : base("name=LinJiaYou")
        {
        }

        public virtual DbSet<ExceptionLogs> ExceptionLogs { get; set; }
        public virtual DbSet<PhoneVeriCodes> PhoneVeriCodes { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Tourists> Tourists { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tourists>()
                .HasMany(e => e.Pictures)
                .WithOptional(e => e.Tourists)
                .HasForeignKey(e => e.Tourist_PrimaryTrackingKeyID);

            modelBuilder.Entity<Tourists>()
                .HasMany(e => e.Pictures1)
                .WithOptional(e => e.Tourists1)
                .HasForeignKey(e => e.TouristID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pictures)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.FromDealshot_id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pictures1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.FromHeadshot_id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pictures2)
                .WithOptional(e => e.Users2)
                .HasForeignKey(e => e.FromUsed_id);
        }
    }
}
