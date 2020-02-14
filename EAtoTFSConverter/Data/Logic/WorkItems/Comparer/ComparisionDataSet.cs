using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class ComparisionDataSet
    {
        public ComparisionDataSet(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType,
            Guid id)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            WorkItemType = workItemType;
            Guid = id;
        }

        public IComparable ActiveEntity { get; set; }
        public IComparable PreviousEntity { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }
    }
}