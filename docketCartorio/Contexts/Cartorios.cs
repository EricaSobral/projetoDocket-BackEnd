using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace docketCartorio.Domains
{
    public partial class CartoriosContext : DbContext
    {
        public CartoriosContext()
        {
        }

        public CartoriosContext(DbContextOptions<CartoriosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartorio> Cartorio { get; set; }
        public virtual DbSet<TipoCertidao> TipoCertidao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-G64P2C3\\SQLEXPRESS; Initial Catalog=Cartorios; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartorio>(entity =>
            {
                entity.HasKey(e => e.IdCartorio);

                entity.HasIndex(e => e.Endereco)
                    .HasName("UQ__Cartorio__4DF3E1FF2A029D7A")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Cartorio__7D8FE3B237FFA139")
                    .IsUnique();

                entity.Property(e => e.IdCartorio).HasColumnName("id_cartorio");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FkTipoCertidao).HasColumnName("fk_tipoCertidao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTipoCertidaoNavigation)
                    .WithMany(p => p.Cartorio)
                    .HasForeignKey(d => d.FkTipoCertidao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cartorio__fk_tip__3D5E1FD2");
            });

            modelBuilder.Entity<TipoCertidao>(entity =>
            {
                entity.HasKey(e => e.IdTipoCerdidao);

                entity.HasIndex(e => e.Certidao)
                    .HasName("UQ__TipoCert__77E92ABA9440D8CB")
                    .IsUnique();

                entity.Property(e => e.IdTipoCerdidao).HasColumnName("id_tipoCerdidao");

                entity.Property(e => e.Certidao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
        }
    }
}
