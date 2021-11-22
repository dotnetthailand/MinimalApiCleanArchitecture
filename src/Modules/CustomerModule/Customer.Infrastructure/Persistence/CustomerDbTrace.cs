namespace Customer.Infrastructure.Persistence;

[RegisterSingleton(For = typeof(ICustomerDbTrace))]
public class CustomerDbTrace : ICustomerDbTrace
{
    private readonly IAuditTraceHandler _auditTraceHandler;

    public CustomerDbTrace(IAuditTraceHandler auditTraceHandler)
    {
        _auditTraceHandler = auditTraceHandler;
    }
    public void AfterAverage(TraceLog log)
    {

    }

    public void AfterAverageAll(TraceLog log)
    {

    }

    public void AfterBatchQuery(TraceLog log)
    {

    }

    public void AfterCount(TraceLog log)
    {

    }

    public void AfterCountAll(TraceLog log)
    {

    }

    public void AfterDelete(TraceLog log)
    {

    }

    public void AfterDeleteAll(TraceLog log)
    {

    }

    public void AfterExecuteNonQuery(TraceLog log)
    {

    }

    public void AfterExecuteQuery(TraceLog log)
    {

    }

    public void AfterExecuteReader(TraceLog log)
    {

    }

    public void AfterExecuteScalar(TraceLog log)
    {

    }

    public void AfterExists(TraceLog log)
    {

    }

    public void AfterInsert(TraceLog log)
    {

    }

    public void AfterInsertAll(TraceLog log)
    {

    }

    public void AfterMax(TraceLog log)
    {

    }

    public void AfterMaxAll(TraceLog log)
    {

    }

    public void AfterMerge(TraceLog log)
    {

    }

    public void AfterMergeAll(TraceLog log)
    {

    }

    public void AfterMin(TraceLog log)
    {

    }

    public void AfterMinAll(TraceLog log)
    {

    }

    public void AfterQuery(TraceLog log)
    {

    }

    public void AfterQueryAll(TraceLog log)
    {

    }

    public void AfterQueryMultiple(TraceLog log)
    {

    }

    public void AfterSum(TraceLog log)
    {

    }

    public void AfterSumAll(TraceLog log)
    {

    }

    public void AfterTruncate(TraceLog log)
    {

    }

    public void AfterUpdate(TraceLog log)
    {

    }

    public void AfterUpdateAll(TraceLog log)
    {

    }

    public void BeforeAverage(CancellableTraceLog log)
    {

    }

    public void BeforeAverageAll(CancellableTraceLog log)
    {

    }

    public void BeforeBatchQuery(CancellableTraceLog log)
    {

    }

    public void BeforeCount(CancellableTraceLog log)
    {

    }

    public void BeforeCountAll(CancellableTraceLog log)
    {

    }

    public void BeforeDelete(CancellableTraceLog log)
    {

    }

    public void BeforeDeleteAll(CancellableTraceLog log)
    {

    }

    public void BeforeExecuteNonQuery(CancellableTraceLog log)
    {

    }

    public void BeforeExecuteQuery(CancellableTraceLog log)
    {

    }

    public void BeforeExecuteReader(CancellableTraceLog log)
    {

    }

    public void BeforeExecuteScalar(CancellableTraceLog log)
    {

    }

    public void BeforeExists(CancellableTraceLog log)
    {

    }

    public void BeforeInsert(CancellableTraceLog log)
    {
        _auditTraceHandler.BeforeInsert(log);

    }

    public void BeforeInsertAll(CancellableTraceLog log)
    {

    }

    public void BeforeMax(CancellableTraceLog log)
    {

    }

    public void BeforeMaxAll(CancellableTraceLog log)
    {

    }

    public void BeforeMerge(CancellableTraceLog log)
    {

    }

    public void BeforeMergeAll(CancellableTraceLog log)
    {

    }

    public void BeforeMin(CancellableTraceLog log)
    {

    }

    public void BeforeMinAll(CancellableTraceLog log)
    {

    }

    public void BeforeQuery(CancellableTraceLog log)
    {

    }

    public void BeforeQueryAll(CancellableTraceLog log)
    {

    }

    public void BeforeQueryMultiple(CancellableTraceLog log)
    {

    }

    public void BeforeSum(CancellableTraceLog log)
    {

    }

    public void BeforeSumAll(CancellableTraceLog log)
    {

    }

    public void BeforeTruncate(CancellableTraceLog log)
    {

    }

    public void BeforeUpdate(CancellableTraceLog log)
    {
        _auditTraceHandler.BeforeUpdate(log);
    }

    public void BeforeUpdateAll(CancellableTraceLog log)
    {

    }
}
