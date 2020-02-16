using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class ComparisionResult : IComparisionResult
    {
        public ComparisionResult(WorkItemType workItemType, Guid id)
        {
            WorkItemType = workItemType;
            Guid = id;
        }

        public ComparisionResult(WorkItemType workItemType)
        {
            WorkItemType = workItemType;
        }

        public ComparisionResult()
        {
        }

        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }
        public Project Project { get; set; }
    }
}