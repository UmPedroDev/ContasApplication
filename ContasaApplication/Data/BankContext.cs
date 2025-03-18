﻿using ContasApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContasApplication.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<DespesaModel> Despesas { get; set; } 
        public DbSet<Mes> Mes { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
    }
}
