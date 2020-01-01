using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparisionDataSet
    {
        public ComparisionDataSet(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType, Guid id)
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
