using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIBooks.Models.Data
{
    public partial class APIBooksContext : DbContext
    {
        public APIBooksContext()
        {
        }

        public APIBooksContext(DbContextOptions<APIBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=APIBooks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");

                entity.HasIndex(e => e.Autor, "UQ__Libro__41C60C60F64C7162")
                    .IsUnique();

                entity.Property(e => e.LibroId).HasColumnName("libroId");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("autor");

                entity.Property(e => e.Editorial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("editorial");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaPublicacion");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
