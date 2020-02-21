
using ContaSimples.BusinessCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContaSimples.BusinessCore.Repositories
{
    public class ContaCorrenteContext : DbContext
    {
        public ContaCorrenteContext(DbContextOptions<ContaCorrenteContext> contextOptions  ) : base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Cliente>()
                        .ToTable("Clientes");

           
            modelBuilder.Entity<ContaCorrente>()
                        .ToTable("ContaCorrente");


            modelBuilder.Entity<ContaCorrente>()
                        .HasOne(x => x.Cliente);

            modelBuilder.Entity<ContaCorrente>()
                      .Ignore(x => x.Saldo);

            modelBuilder.Entity<Lancamento>()
                        .ToTable("Lancamentos");

            modelBuilder.Entity<Lancamento>()
                        .HasOne(x => x.ContaCorrente);

        }


        public DbSet<Cliente> Clientes { get; set; }


        public DbSet<Lancamento> Lancamentos { get; set; }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }

    }
}
