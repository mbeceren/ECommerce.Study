using ECommerce.Study.Domain.Models;
using System.Data.Entity;

namespace ECommerce.Study.Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(string connectionString) 
			: base(connectionString)
		{
			Database.SetInitializer<ApplicationContext>(null);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Product>().ToTable(nameof(Product));
			modelBuilder.Entity<Stock>().ToTable(nameof(Stock));
			modelBuilder.Entity<User>().ToTable(nameof(User));

			modelBuilder.Entity<Product>()
				.HasRequired(x => x.Stock)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.StockId);

			base.OnModelCreating(modelBuilder);
		}
	}

}
