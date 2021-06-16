using Db.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Db
{
    public interface IAuditDbContext
    {
        DbSet<Auditable> Audit { get; set; }

        ChangeTracker ChangeTracker { get; }

    }
}