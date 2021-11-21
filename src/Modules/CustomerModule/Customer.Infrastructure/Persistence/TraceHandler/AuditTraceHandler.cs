namespace Customer.Infrastructure.Persistence.TraceHandler;

using Agoda.IoC.Core;
using RepoDb;
using SharedKernel.Entities;

public interface IAuditTraceHandler
{
    void BeforeInsert(CancellableTraceLog log);
    void BeforeUpdate(CancellableTraceLog log);
}

[RegisterSingleton]
public class AuditTraceHandler : IAuditTraceHandler
{
    public void BeforeInsert(CancellableTraceLog log)
    {
        if (log?.Parameter is AuditableEntity auditableEntity)
        {
            auditableEntity.CreatedDate = DateTime.Now;
            auditableEntity.LastModifiedDate = DateTime.Now;
        }
    }

    public void BeforeUpdate(CancellableTraceLog log)
    {
        if (log?.Parameter is AuditableEntity auditableEntity)
        {
            auditableEntity.LastModifiedDate = DateTime.Now;
        }
    }
}
