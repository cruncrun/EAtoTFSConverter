using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    public class ComparsionResult
    {
        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }

        public ComparsionResult(WorkItemType workItemType)
        {
            WorkItemType = workItemType;
        }

        public ComparsionResult()
        {
            
        }
    }
}
