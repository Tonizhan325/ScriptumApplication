using Microsoft.EntityFrameworkCore;
using ScriptumApplication.Models;

namespace ScriptumApplication.Data
{
    public class ScriptumContexto : DbContext
    {
        public ScriptumContexto(DbContextOptions<ScriptumContexto> options)
        : base(options)
        {
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Descarga>? Descargas { get; set; }
        public DbSet<Subida>? Subidas { get; set; }
        public DbSet<Genero>? Genero { get; set; }
        public DbSet<Reseña>? Reseñas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Poner el nombre de las tablas en singular
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Descarga>().ToTable("Descarga");
            modelBuilder.Entity<Subida>().ToTable("Subida");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<Reseña>().ToTable("Reseña");
            // Deshabilitar la eliminación en cascada en todas las relaciones

            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
