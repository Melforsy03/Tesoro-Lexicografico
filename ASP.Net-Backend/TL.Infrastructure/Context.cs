using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TL.Domain.Entidades;
using TL.Domain.Relaciones;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TL.Infrastructure.Identity;

namespace TL.Infrastructure
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Acepcion> Acepciones { get; set; }
        public DbSet<Diccionario> Diccionarios { get; set; }
        public DbSet<Editor> Editores { get; set; }
        public DbSet<Metadatos> Metadatos { get; set; }
        public DbSet<Termino> Terminos { get; set; }
        public DbSet<DiccionarioTermino> Entradas {  get; set; }
        public DbSet<SubEntrada> SubEntradas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Acepcion>(entity =>
            {
                entity.HasKey(e => e.IdAc);
                entity.Property(e => e.NumDef);
                entity.Property(e => e.Pais);
                entity.Property(e => e.ClasePal);
                entity.Property(e => e.ClaseSem);
                entity.Property(e => e.Def);
                entity.Property(e => e.Etim);
                entity.HasOne(e => e.Entrada).WithMany().HasForeignKey(e => e.IdAc).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Diccionario>(entity =>
            {
                entity.HasKey(e => e.IdDic);
                entity.Property(e => e.DicNombre);
            });

            modelBuilder.Entity<Metadatos>(entity =>
            {
                entity.HasKey(e => e.IdMet);
                entity.Property(e => e.Pais);
                entity.Property(e => e.NombreDeProyecto);
                entity.Property(e => e.NombreDePrologo);
                entity.Property(e => e.PrologoURL);
                entity.Property(e => e.Autor);
                entity.Property(e => e.CodigoDePais);
                entity.Property(e => e.Edicion);
                entity.Property(e => e.FechaDePublicacion);
                entity.Property(e => e.FechaDeRevision);
                entity.Property(e => e.FechaDeTranscripcion);
                entity.Property(e => e.FechaOriginal);
                entity.Property(e => e.FuenteURL);
                entity.Property(e => e.LugarDePublicacion);
                entity.Property(e => e.NombreDeFuente);
                entity.Property(e => e.Transcriptor);
                entity.Property(e => e.Titulo);
                entity.Property(e => e.TituloCompleto);
                entity.Property(e => e.Siglo);
                entity.Property(e => e.Revisor);
                entity.Property(e => e.Remarks);
                entity.Property(e => e.Publicador);
                entity.HasOne(e => e.Diccionario).WithMany().HasForeignKey(e => e.IdDic).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Editor>(entity =>
            {
                entity.HasKey(e => e.IdEd);
                entity.Property(e => e.EsAdmin);
                entity.Property(e => e.NomEd);
            });
            
            modelBuilder.Entity<Termino>(entity =>
            {
                entity.HasKey(e => e.IdTer);
                entity.Property(e => e.NomReg);

            });

            modelBuilder.Entity<DiccionarioTermino>(entity =>
            {
                entity.HasKey(dt => dt.IdDicTer);
                entity.Property(dt => dt.EsSubEntrada);
                entity.Property(dt => dt.EsSuperEntrada);
                entity.Property(dt => dt.NomEntrada);
                entity.HasOne(dt => dt.Diccionario).WithMany().HasForeignKey(dt => dt.IdDic).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(dt => dt.Termino).WithMany().HasForeignKey(dt => dt.IdTer).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<SubEntrada>(entity => 
            {
                entity.HasKey(e => e.IdSubEnt);
                entity.HasOne(e => e.EntradaPadre).WithMany().HasForeignKey(e => e.IdEntPadre).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.EntradaHijo).WithMany().HasForeignKey(e => e.IdEntHijo).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
