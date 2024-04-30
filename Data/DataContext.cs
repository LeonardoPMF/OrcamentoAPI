using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Despesa> Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

     modelBuilder.Entity<Orcamento>().ToTable("Budget");
    
    // Dados de inicialização para a tabela Orcamento
    modelBuilder.Entity<Orcamento>().HasData(
        new Orcamento { Id = 1, Nome = "Orcamento Inicial", Valor = 1000m, Data = DateTime.Now, Descricao = "Descrição inicial", Categoria = 1 }
    );

    // Dados de inicialização para a tabela Despesa
    modelBuilder.Entity<Despesa>().HasData(
        new Despesa { Id = 1, Nome = "Despesa Inicial", Valor = 100m, Data = DateTime.Now, Descricao = "Descrição inicial", Categoria = 1 }
    );
  }
 }
}