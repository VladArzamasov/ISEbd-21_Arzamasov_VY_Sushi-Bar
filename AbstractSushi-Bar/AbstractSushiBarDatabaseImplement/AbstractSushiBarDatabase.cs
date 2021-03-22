using AbstractSushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractSushiBarDatabaseImplement
{
    public class AbstractSushiBarDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AbstractSushiBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Sushi> Sushi { set; get; }
        public virtual DbSet<SushiComponent> SushiComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
