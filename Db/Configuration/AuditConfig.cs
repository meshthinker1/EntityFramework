using Db.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Configuration
{
    internal class AuditConfig : IEntityTypeConfiguration<Auditable>
    {
        public void Configure(EntityTypeBuilder<Auditable> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("AuditDataChange");

            entity.Property(e => e.Id)
                .HasColumnName("Id");
            entity.Property(e => e.EventTimeUtc)
                .HasColumnName("EventTimeUtc");
            entity.Property(e => e.EventType)
                .HasColumnName("EventType");
            entity.Property(e => e.UserName)
                .HasColumnName("UserName");
            entity.Property(e => e.TableName)
                .HasColumnName("TableName");
            entity.Property(e => e.KeyValue)
                .HasColumnName("KeyValue");
            entity.Property(e => e.OldValue)
                .HasColumnName("OldValue");
            entity.Property(e => e.NewValue)
                .HasColumnName("NewValue");
            entity.Property(e => e.ChangedColumns)
                .HasColumnName("ChangedColumns");
        }
    }
}