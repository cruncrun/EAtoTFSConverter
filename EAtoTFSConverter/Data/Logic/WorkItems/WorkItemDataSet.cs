using System.Collections.Generic;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;

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
