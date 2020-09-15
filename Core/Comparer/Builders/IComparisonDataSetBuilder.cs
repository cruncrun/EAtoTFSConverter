using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer.Builders
{
    public interface IComparisonDataSetBuilder
    {
        IComparisonDataSetBuilder SetGuid(Guid guid);
        IComparisonDataSetBuilder SetWorkItemType(WorkItemType workItemType);
        IComparisonDataSetBuilder SetActiveEntity(IComparisonEntity entity);
        IComparisonDataSetBuilder SetPreviousEntity(IComparisonEntity entity);
        IComparisonDataSet Build();
    }
}
