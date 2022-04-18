using admCondominio.Models;
using Microsoft.EntityFrameworkCore;

namespace admCondominio.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Condominio> Condominios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=adm_condominio;Username=postgres;Password=748596");
    }
}