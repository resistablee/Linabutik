using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Context : DbContext
    {
        public Context()  : base("name=Context")
        {
            //Performans için bunu kapattık. Detaylı bilgi: https://medium.com/hesapkurdu-development/entity-framework-bildiğiniz-üzere-microsoftun-geliştirdiği-bir-orm-aracı-181b47056f9a
            //ve https://hakantopuz.medium.com/entity-frameworkte-performans-i̇puçları-d1e0b0071ac0
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.AutoDetectChangesEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                        .HasRequired(m => m.PaymentType)
                        .WithMany(t => t.awer50)
                        .HasForeignKey(m => m.PaymentTypeID);

            modelBuilder.Entity<Orders>()
                        .HasRequired(m => m.Customer)
                        .WithMany(t => t.awer60)
                        .HasForeignKey(m => m.CustomerID);

            modelBuilder.Entity<Orders>()
                        .HasRequired(m => m.OrderStatus)
                        .WithMany(t => t.awer41)
                        .HasForeignKey(m => m.OrderStatusID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                        .HasRequired(m => m.Address)
                        .WithMany(t => t.awer42)
                        .HasForeignKey(m => m.AddressID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                        .HasRequired(m => m.CardType)
                        .WithMany(t => t.awer80)
                        .HasForeignKey(m => m.CardTypeID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetails>()
                        .HasRequired(m => m.OrderStatus)
                        .WithMany(t => t.awer16)
                        .HasForeignKey(m => m.OrderStatusID)
                        .WillCascadeOnDelete(false);


            modelBuilder.Entity<Products>()
                        .HasRequired(m => m.Color)
                        .WithMany(t => t.awer17)
                        .HasForeignKey(m => m.ColorID)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Products>()
                        .HasRequired(m => m.Size)
                        .WithMany(t => t.awer18)
                        .HasForeignKey(m => m.SizeID)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Products>()
                        .HasRequired(m => m.Category)
                        .WithMany(t => t.awer19)
                        .HasForeignKey(m => m.CategoryID)
                        .WillCascadeOnDelete(false);


            modelBuilder.Entity<Operations>()
                        .HasRequired(m => m.OperationType)
                        .WithMany(t => t.awer20)
                        .HasForeignKey(m => m.OperationTypeID)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Operations>()
                        .HasRequired(m => m.PersonType)
                        .WithMany(t => t.awer21)
                        .HasForeignKey(m => m.PersonTypeID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                        .HasRequired(m => m.City)
                        .WithMany(t => t.awer7)
                        .HasForeignKey(m => m.CityID)
                        .WillCascadeOnDelete(false);


            modelBuilder.Entity<OrderDetails>()
                        .HasRequired(m => m.Product)
                        .WithMany(t => t.awer26)
                        .HasForeignKey(m => m.ProductID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<CargoInfo>()
                        .HasRequired(m => m.Address)
                        .WithMany(t => t.awer2)
                        .HasForeignKey(m => m.AddressID)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<CargoInfo>()
                        .HasRequired(m => m.Customer)
                        .WithMany(t => t.awer14)
                        .HasForeignKey(m => m.CustomerID)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<CargoInfo>()
                        .HasRequired(m => m.Order)
                        .WithMany(t => t.awer25)
                        .HasForeignKey(m => m.OrderID)
                        .WillCascadeOnDelete(false);


            modelBuilder.Entity<Customers>()
                        .HasRequired(m => m.Gender)
                        .WithMany(t => t.awer39)
                        .HasForeignKey(m => m.GenderID)
                        .WillCascadeOnDelete(false);
        }



        public DbSet<Addresses> Address { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Brands> Brand { get; set; }
        public DbSet<CargoInfo> CargoInfo { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Favorites> Favorite { get; set; }
        public DbSet<Features> Feature { get; set; }
        public DbSet<FeatureTypes> FeatureType { get; set; }
        public DbSet<Managers> Manager { get; set; }
        public DbSet<Operations> Operation { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<ProductImages> ProductImage { get; set; }
        public DbSet<Products> Product { get; set; }
    }
}