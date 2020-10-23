using System;
using System.Collections.Generic;
using System.Text;
//Using agregados
using Microsoft.EntityFrameworkCore;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Agenda.db");
        }
    }
}
