using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparisionResult : IComparisionResult
    {
        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }

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
    }
}
