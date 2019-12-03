using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;
using System.Collections.Generic;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemDataSet
    {
        public Project Project { get; set; }
        public ICreatable TestPlan { get; set; }
        public ICreatable TestSuite { get; set; }
        public IEnumerable<ICreatable> TestCases { get; set; }
    }
}
