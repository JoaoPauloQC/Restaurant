using Restaurant.Models;
using Microsoft.EntityFrameworkCore;


namespace Restaurant.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(

                new Item { Id = 1 ,  Name = "X-Burguer", Description = "O saboroso e mais aclamado da casa!", Price = 20.90 },
                new Item { Id = 2, Name = "X-House", Description = "O preferido", Price = 30.90 },
                new Item { Id = 3 , Name = "Strogonoff", Description = "O delicioso e mais pedido", Price = 22.90 },
                new Item { Id = 4 , Name = "Secret", Description = "O sabor especial e secreto do chefe", Price = 24.90 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
