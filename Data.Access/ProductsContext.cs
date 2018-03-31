using Data.Access.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Access
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("ShoppingCenterDb")
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<DiscountGroup> DiscountGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
