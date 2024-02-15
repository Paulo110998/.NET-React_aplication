using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stepforma_BR.Models;

namespace Stepforma_BR.Data;


public class UsuariosContext : IdentityDbContext<Usuario>
{
    public UsuariosContext(DbContextOptions<UsuariosContext> options)
        : base(options) { }

    // Resolvendo o erro “Specified key was too long” no Identity Core com MySQL
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(m => m.Id).HasMaxLength(110);
            entity.Property(m => m.Email).HasMaxLength(127);
            entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
            entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
            entity.Property(m => m.UserName).HasMaxLength(127);
        });
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.Property(m => m.Id).HasMaxLength(200);
            entity.Property(m => m.Name).HasMaxLength(127);
            entity.Property(m => m.NormalizedName).HasMaxLength(127);
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.Property(m => m.LoginProvider).HasMaxLength(50);
            entity.Property(m => m.ProviderKey).HasMaxLength(50);
        });
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.Property(m => m.UserId).HasMaxLength(50);
            entity.Property(m => m.RoleId).HasMaxLength(50);
        });
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.Property(m => m.UserId).HasMaxLength(50);
            entity.Property(m => m.LoginProvider).HasMaxLength(50);
            entity.Property(m => m.Name).HasMaxLength(110);

        });



    }
}


