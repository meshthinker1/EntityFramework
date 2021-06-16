using Db.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Configuration
{
    internal class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Role", "auth");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50);

            entity.Property(e => e.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .HasMaxLength(50);

            entity.Property(e => e.NormalizedName)
                .HasColumnName("NormalizedName")
                .HasMaxLength(150);
        }
    }
}