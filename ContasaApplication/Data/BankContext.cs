using ContasApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContasApplication.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) 
        {
        }

        public DbSet<DespesaModel> Despesas { get; set; } 
        public DbSet<Mes> Mes { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
