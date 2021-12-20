using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BGuilaTour.Models
{
    public partial class BGuilaTourBDContext : DbContext
    {

        public BGuilaTourBDContext(DbContextOptions<BGuilaTourBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acomapanhante> Acomapanhantes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteExcursao> ClienteExcursaos { get; set; }
        public virtual DbSet<Excursao> Excursaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
                optionsBuilder.UseSqlServer("Server=(local);Database=BGuilaTourBD;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Acomapanhante>(entity =>
            {
                entity.HasKey(e => e.IdAcompanhante)
                    .HasName("PK__Acomapan__5071590E8AD9CC6D");

                entity.ToTable("Acomapanhante");

                entity.HasIndex(e => e.Cpf, "UQ__Acomapan__C1FF9309469F2ED1")
                    .IsUnique();

                entity.Property(e => e.IdAcompanhante).HasColumnName("Id_Acompanhante");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataNasc)
                    .HasColumnType("date")
                    .HasColumnName("Data_Nasc");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ResponsavelNavigation)
                    .WithMany(p => p.Acomapanhantes)
                    .HasForeignKey(d => d.Responsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acomapanhante");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__3DD0A8CB42352A05");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Cpf, "UQ__Cliente__D836E71FDD16BBB9")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNasc)
                    .HasColumnType("date")
                    .HasColumnName("Data_Nasc");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ClienteExcursao>(entity =>
            {
                entity.HasKey(e => e.IdClieEx)
                    .HasName("PK__Cliente___AA11BFA552DE0E06");

                entity.ToTable("Cliente_Excursao");

                entity.Property(e => e.IdClieEx).HasColumnName("Id_CLieEx");

                entity.Property(e => e.NCliente).HasColumnName("N_Cliente");

                entity.Property(e => e.NExcursao).HasColumnName("N_Excursao");

                entity.HasOne(d => d.NClienteNavigation)
                    .WithMany(p => p.ClienteExcursaos)
                    .HasForeignKey(d => d.NCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Excursao");

                entity.HasOne(d => d.NExcursaoNavigation)
                    .WithMany(p => p.ClienteExcursaos)
                    .HasForeignKey(d => d.NExcursao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Excursao_Cliente_Excursao");
            });

            modelBuilder.Entity<Excursao>(entity =>
            {
                entity.HasKey(e => e.IdExcursao)
                    .HasName("PK__Excursao__A8682F1580305788");

                entity.ToTable("Excursao");

                entity.Property(e => e.IdExcursao).HasColumnName("Id_Excursao");

                entity.Property(e => e.DataIda)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Data_ida");

                entity.Property(e => e.DataVolta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Data_volta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
