
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace DatLog
{
    public class PokestoreDBContext : DbContext
    {

        public PokestoreDBContext(DbContextOptions options) : base(options)
        {

        }

        protected PokestoreDBContext() 
        {

        }
        

        

        public DbSet<Customer> Customers { get; set;}
        public DbSet<Order> Orders { get; set;}

        public DbSet<Manager> Managers { get; set;}
        public DbSet<Inventory> Inventories { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<Storefront> Storefronts { get; set;}
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .Property(Custo => Custo.ID)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
            .Property(orde => orde.IDs)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Manager>()
            .Property(manag => manag.ID)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Inventory>()
            .Property(inven => inven.InventoryId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
            .Property(produ => produ.ProductCode)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Storefront>()
            .Property(storef => storef.storeID)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<LineItem>()
            .Property(linei => linei.itemID)
            .ValueGeneratedOnAdd();



        }


    }
}