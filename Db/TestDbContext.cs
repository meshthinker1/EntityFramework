using System;
using Db.Table;
using Db.Configuration;
using Microsoft.EntityFrameworkCore;
using Db.Helper.AuditTrail;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Db
{
    public abstract class TestDbContext : DbContext, ITestDbContext
    {
        public virtual DbSet<Auditable> Audit { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected TestDbContext() : base()
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditConfig());
            modelBuilder.ApplyConfiguration(new InstitutionConfig());
        }

        public virtual int SaveChanges(string userName)
        {
            new AuditHelper(this).AddAuditLogs(userName);
            var result = SaveChanges();
            return result;
        }
        
        /*
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
           // new AuditHelper(this).AddAuditLogs(userName);
            //var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            //await OnAfterSaveChanges(auditEntries);
            return result;
        }
        */

    }
}
