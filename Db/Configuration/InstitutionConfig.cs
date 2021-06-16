using Db.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Configuration
{
    internal class InstitutionConfig : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Institution");

            entity.Property(e => e.Id)
                .HasColumnName("Id");
            entity.Property(e => e.SalesForceId)
                .HasColumnName("SalesForceId");
            entity.Property(e => e.SapCustomerId)
                .HasColumnName("SapCustomerId");
            entity.Property(e => e.DisplayName)
                .HasColumnName("DisplayName");
            entity.Property(e => e.Location)
                .HasColumnName("Location");
            entity.Property(e => e.CreatedUtc)
                .HasColumnName("CreatedUtc");
            entity.Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy");
            entity.Property(e => e.LastModifiedUtc)
                .HasColumnName("LastModifiedUtc");
            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("LastModifiedBy");
            entity.Property(e => e.Deleted)
               .HasColumnName("Deleted");
            entity.Property(e => e.GlobalDisplayName)
                .HasColumnName("GlobalDisplayName");
            entity.Property(e => e.IdpId)
                .HasColumnName("IdpId");
            entity.Property(e => e.Scopes)
                .HasColumnName("Scopes");
            entity.Property(e => e.IdpMatchingRegEx)
                .HasColumnName("IdpMatchingRegEx");
        }
    }
}