using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer.Builders
{
    public interface IComparisonResultBuilder
    {
        IComparisonResultBuilder SetGuid(Guid guid);
        IComparisonResultBuilder SetOperationType(OperationType operationType);
        IComparisonResultBuilder SetWorkItemType(WorkItemType workItemType);
        IComparisonResultBuilder SetProject(Project project);
        IComparisonResult Build();
    }
}
