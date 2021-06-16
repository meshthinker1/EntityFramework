using Db.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace Db
{
    public interface ITestDbContext : IAuditDbContext, IDisposable
    {
        DbSet<Role> Role { get; set; }

        DbSet<Institution> Institution { get; set; }

        DatabaseFacade Database { get; }
        int SaveChanges(string userName);
       // async Task<int> SaveChangesAsync();
    }
}
