using CadastroClientes.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesCore.Data
{
    public class CadastroClientesContext : DbContext
    {
        public DbSet<ModeloCliente> clientes { get; set; }
        string dbPath;
        
        public CadastroClientesContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = System.IO.Path.Join(path, "CadastroClientes.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModeloCliente>().HasKey(c => c.CPF);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbPath}");
    }

}
