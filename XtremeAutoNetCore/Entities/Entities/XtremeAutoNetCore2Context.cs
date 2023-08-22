using System;
using System.Collections.Generic;
using Entities.Authentication;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class XtremeAutoNetCore2Context : IdentityDbContext<ApplicationUser>
    {
        public XtremeAutoNetCore2Context()
        {
            var optionBuilder = new DbContextOptionsBuilder<XtremeAutoNetCore2Context>();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public XtremeAutoNetCore2Context(DbContextOptions<XtremeAutoNetCore2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<CarroModelo> CarroModelos { get; set; } = null!;
        public virtual DbSet<CarroVendido> CarroVendidos { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Ruedum> Rueda { get; set; } = null!;
        public virtual DbSet<Seguro> Seguros { get; set; } = null!;
        public virtual DbSet<Tarjetum> Tarjeta { get; set; } = null!;
        public virtual DbSet<Transaccion> Transaccions { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CarroModelo>(entity =>
            {
                entity.ToTable("CarroModelo");

                entity.Property(e => e.CarroModeloId).HasColumnName("CarroModeloID");

                entity.Property(e => e.Descripcion).HasMaxLength(4000);

                entity.Property(e => e.Imagen).HasMaxLength(256);

                entity.Property(e => e.Marca).HasMaxLength(60);

                entity.Property(e => e.Modelo).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tipo).HasMaxLength(30);
            });

            modelBuilder.Entity<CarroVendido>(entity =>
            {
                entity.ToTable("CarroVendido");

                entity.HasIndex(e => e.CarroModeloId, "IX_CarroVendido_CarroModeloID");

                entity.HasIndex(e => e.ColorId, "IX_CarroVendido_ColorID");

                entity.HasIndex(e => e.RuedaId, "IX_CarroVendido_RuedaID");

                entity.HasIndex(e => e.SeguroId, "IX_CarroVendido_SeguroID");

                entity.Property(e => e.CarroVendidoId).HasColumnName("CarroVendidoID");

                entity.Property(e => e.CarroModeloId).HasColumnName("CarroModeloID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RuedaId).HasColumnName("RuedaID");

                entity.Property(e => e.SeguroId).HasColumnName("SeguroID");

                entity.HasOne(d => d.CarroModelo)
                    .WithMany(p => p.CarroVendidos)
                    .HasForeignKey(d => d.CarroModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarroVend__Carro__4222D4EF");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.CarroVendidos)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarroVend__Color__412EB0B6");

                entity.HasOne(d => d.Rueda)
                    .WithMany(p => p.CarroVendidos)
                    .HasForeignKey(d => d.RuedaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarroVend__Rueda__403A8C7D");

                entity.HasOne(d => d.Seguro)
                    .WithMany(p => p.CarroVendidos)
                    .HasForeignKey(d => d.SeguroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarroVend__Segur__4316F928");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Imagen).HasMaxLength(256);

                entity.Property(e => e.Nombre).HasMaxLength(30);
            });

            modelBuilder.Entity<Ruedum>(entity =>
            {
                entity.HasKey(e => e.RuedaId)
                    .HasName("PK__Rueda__7CFBF784C815919B");

                entity.Property(e => e.RuedaId).HasColumnName("RuedaID");

                entity.Property(e => e.Imagen).HasMaxLength(256);

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.ToTable("Seguro");

                entity.Property(e => e.SeguroId).HasColumnName("SeguroID");

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Tarjetum>(entity =>
            {
                entity.HasKey(e => e.TarjetaId)
                    .HasName("PK__Tarjeta__C82506965114A29B");

                entity.HasIndex(e => e.UsuarioId, "IX_Tarjeta_UsuarioID");

                entity.Property(e => e.TarjetaId).HasColumnName("TarjetaID");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(10)
                    .HasColumnName("CVV");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(60);

                entity.Property(e => e.NumeroDeTarjeta).HasMaxLength(30);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Tarjeta_AspNetUsers");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.ToTable("Transaccion");

                entity.HasIndex(e => e.TarjetaId, "IX_Transaccion_TarjetaID");

                entity.HasIndex(e => e.VentaId, "IX_Transaccion_VentaID");

                entity.Property(e => e.TransaccionId).HasColumnName("TransaccionID");

                entity.Property(e => e.FechaCorte).HasColumnType("datetime");

                entity.Property(e => e.FechaTransaccion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InteresesMorosidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TarjetaId).HasColumnName("TarjetaID");

                entity.Property(e => e.VentaId).HasColumnName("VentaID");

                entity.HasOne(d => d.Tarjeta)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.TarjetaId)
                    .HasConstraintName("FK__Transacci__Tarje__5DCAEF64");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacci__Venta__5EBF139D");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.VentaId)
                    .HasName("PK__Venta__5B41514C2F6414C9");

                entity.HasIndex(e => e.CarroVendidoId, "IX_Venta_CarroVendidoID");

                entity.HasIndex(e => e.UsuarioId, "IX_Venta_UsuarioID");

                entity.Property(e => e.VentaId).HasColumnName("VentaID");

                entity.Property(e => e.CarroVendidoId).HasColumnName("CarroVendidoID");

                entity.Property(e => e.Intereses).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaldoAbonado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaldoPendiente).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.CarroVendido)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CarroVendidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__CarroVend__49C3F6B7");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Venta_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
