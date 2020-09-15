using System;

namespace Core.Comparer.Abstractions
{
    public interface IComparisonDataSet
    {
        IComparisonEntity ActiveEntity { get; set; }
        IComparisonEntity PreviousEntity { get; set; }
        WorkItemType WorkItemType { get; set; }
        Guid Guid { get; set; }
    }
}