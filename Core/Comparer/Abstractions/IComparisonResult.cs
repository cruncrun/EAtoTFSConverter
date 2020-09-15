using System;

namespace Core.Comparer.Abstractions
{
    public interface IComparisonResult
    {
        bool Result { get; set; }
        OperationType OperationType { get; set; }
        WorkItemType WorkItemType { get; set; }
        Guid Guid { get; set; }
        Project Project { get; set; }
    }
}