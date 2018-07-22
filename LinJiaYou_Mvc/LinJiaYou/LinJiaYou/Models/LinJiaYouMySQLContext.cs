namespace LinJiaYou.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LinJiaYouMySQLContext : DbContext
    {
        public LinJiaYouContext()
            : base("name=LinJiaYouContext")
        {
        }
        public LinJiaYouContext(System.Data.Common.DbConnection dbConnection, bool contextOwnsConnection) : base(dbConnection, contextOwnsConnection)
        { }

        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public virtual DbSet<PhoneVeriCode> PhoneVeriCodes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<County> Countys { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Class1> Class1s { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<QiNiuPicture> QiNiuPictures { get; set; }

        public System.Data.Entity.DbSet<LinJiaYou.Models.Essay> Essays { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tourist>()
        //        .HasMany(e => e.Pictures)
        //        .WithOptional(e => e.Tourist)
        //        .HasForeignKey(e => e.Tourist_PrimaryTrackingKeyID);

        //    //modelBuilder.Entity<Tourists>()
        //    //    .HasMany(e => e.Pictures1)
        //    //    .WithOptional(e => e.Tourists1)
        //    //    .HasForeignKey(e => e.TouristID);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Pictures)
        //        .WithOptional(e => e.Users)
        //        .HasForeignKey(e => e.FromDealshot_id);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Pictures1)
        //        .WithOptional(e => e.Users1)
        //        .HasForeignKey(e => e.FromHeadshot_id);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Pictures2)
        //        .WithOptional(e => e.Users2)
        //        .HasForeignKey(e => e.FromUsed_id);
        //}
    }
}
