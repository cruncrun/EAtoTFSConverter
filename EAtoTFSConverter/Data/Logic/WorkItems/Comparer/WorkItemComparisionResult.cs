using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    class WorkItemComparisionResult
    {
        public WorkItemComparisionResult(WorkItemType workItemType, Guid Id, ComparisionResult result)
        {
            WorkItemType = workItemType;
            Guid = Id;
            ComparisionResult = result;
        }

        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }
        public ComparisionResult ComparisionResult { get; set; }
    }
}
