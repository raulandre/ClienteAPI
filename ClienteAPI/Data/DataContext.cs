using ClienteAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) 
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
