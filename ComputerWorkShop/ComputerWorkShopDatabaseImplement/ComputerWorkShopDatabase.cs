using ComputerWorkShopDatabaseImplement.Models;
using ComputerWorkShoprDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerWorkShopDatabaseImplement
{
    public class ComputerWorkShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=WORKGROUP\SQLEXPRESS;Initial Catalog=ComputerWorkShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Computer> Computers { set; get; }
        public virtual DbSet<ComputerComponent> ComputerComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
