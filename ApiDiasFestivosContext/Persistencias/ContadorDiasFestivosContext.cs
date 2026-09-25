using ApiDiasFestivosDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ApiDiasFestivosInfraestructura.Persistencias
{
    public class ContadorDeDIasFestivosContext : DbContext

    {

        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<TipoFestivo> TiposFestivos { get; set; }

        protected override void OnModelCreating(ModelBuilder constructor)
        {

            constructor.Entity<TipoFestivo>(entidadTipoFestivos =>
            {
                entidadTipoFestivos.HasKey(e => e.Id);      
                entidadTipoFestivos.HasIndex(e => e.Tipo).IsUnique();
            }
              );

            constructor.Entity<Pais>(entidadPais =>
            {
                entidadPais.HasKey(e => e.Id);
                entidadPais.HasIndex(e => e.Nombre).IsUnique();
            }); 
                

            constructor.Entity<Festivo>()
                .HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.IdPais);
            constructor.Entity<Festivo>()
                .HasOne(e => e.Tipo)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);



        }
    }
}
