using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System.Collections.Generic;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    class WorkItemDataSet
    {
        public Project Project { get; set; }
        public ICreatable TestPlan { get; set; }
        public ICreatable TestSuite { get; set; }
        public IEnumerable<ICreatable> TestCases { get; set; }
    }
}
