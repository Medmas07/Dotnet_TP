using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(
        SaveChangesCompletedEventData eventData,
        int result)
    {
        var context = eventData.Context;

        if (context == null)
            return base.SavedChanges(eventData, result);

        var auditEntries = context.ChangeTracker.Entries()
            .Where(e =>
                e.State == EntityState.Added ||
                e.State == EntityState.Modified ||
                e.State == EntityState.Deleted)
            .ToList();

        foreach (var entry in auditEntries)
        {
            if (entry.Entity is AuditLog)
                continue; // éviter boucle infinie

            var audit = new AuditLog
            {
                TableName = entry.Entity.GetType().Name,
                Action = entry.State.ToString(),
                EntityKey = entry.Properties
                    .First(p => p.Metadata.IsPrimaryKey())
                    .CurrentValue?.ToString(),
                Date = DateTime.UtcNow
            };

            context.Set<AuditLog>().Add(audit);
        }

        context.SaveChanges();

        return base.SavedChanges(eventData, result);
    }
}