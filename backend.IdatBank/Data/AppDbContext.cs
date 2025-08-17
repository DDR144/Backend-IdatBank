using backend.IdatBank.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.IdatBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Cuenta> Cuentas => Set<Cuenta>();
        public DbSet<Transferencia> Transferencias => Set<Transferencia>();
    }
}
