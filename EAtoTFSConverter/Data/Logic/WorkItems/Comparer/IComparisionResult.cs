using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public interface IComparisionResult
    {
        bool Result { get; set; }
        OperationType OperationType { get; set; }
        WorkItemType WorkItemType { get; set; }
        Guid Guid { get; set; }
    }
}