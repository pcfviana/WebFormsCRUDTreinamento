using Implanta.WebFormsCRUD.Data.ModelBuilderConfigurations;
using System.Data.Entity;

namespace Implanta.WebFormsCRUD.Data
{
    public class WebFormsCRUDDbContext : DbContext
    {
        static WebFormsCRUDDbContext()
        {
            System.Data.Entity.Database.SetInitializer<WebFormsCRUDDbContext>(null);
        }

        public WebFormsCRUDDbContext()
            : base("Name=WebFormsCRUD")
        {

        }
        public DbSet<Pagamentos> Pagamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PagamentosConfiguration());            
        }
    }
}
