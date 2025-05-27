using Restaurant.Models;
using Microsoft.EntityFrameworkCore;


namespace Restaurant.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {
        }


        public DbSet<MesaItem> mesasitens { get; set; }
        public DbSet<Mesa> mesas { get; set; }
        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MesaItem>()
                .HasKey(m => m.Id);


            modelBuilder.Entity<MesaItem>()
                .HasOne(mi => mi.mesa)
                .WithMany(m => m.MesaItens)
                .HasForeignKey(mi => mi.MesaId);

            modelBuilder.Entity<MesaItem>()
                .HasOne(mi => mi.item)
                .WithMany(i => i.MesaItens)
                .HasForeignKey(mi => mi.ItemId);


            modelBuilder.Entity<Status>().HasData(

                new Status { StatusId = 1, Name = "Aberta" },
                new Status { StatusId = 2, Name = "Fechada" }


                );

            modelBuilder.Entity<Mesa>().HasData(
                    new Mesa { MesaId = 1, StatusId = 1  },
                    new Mesa { MesaId = 2, StatusId = 1 },
                    new Mesa { MesaId = 3, StatusId = 1 },
                    new Mesa { MesaId = 4, StatusId = 1 },
                    new Mesa { MesaId = 5, StatusId = 1 },
                    new Mesa { MesaId = 6, StatusId = 1 },
                    new Mesa { MesaId = 7, StatusId = 1 },
                    new Mesa { MesaId = 8, StatusId = 1 },
                    new Mesa { MesaId = 9, StatusId = 1 },
                    new Mesa { MesaId = 10, StatusId = 1 },
                    new Mesa { MesaId = 11, StatusId = 1 },
                    new Mesa { MesaId = 12, StatusId = 1 },
                    new Mesa { MesaId = 13, StatusId = 1 },
                    new Mesa { MesaId = 14, StatusId = 1 },
                    new Mesa { MesaId = 15, StatusId = 1 }


                );

            


            modelBuilder.Entity<Item>().HasData(

                new Item { ItemId = 1 ,  Name = "X-Burguer", Description = "O saboroso e mais aclamado da casa!", Price = 20.90 },
                new Item { ItemId = 2, Name = "X-House", Description = "O preferido", Price = 30.90 },
                new Item { ItemId = 3 , Name = "Strogonoff", Description = "O delicioso e mais pedido", Price = 22.90 },
                new Item { ItemId = 4 , Name = "Secret", Description = "O sabor especial e secreto do chefe", Price = 24.90 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
