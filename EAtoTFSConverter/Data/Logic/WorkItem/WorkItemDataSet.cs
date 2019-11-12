using System.Collections.Generic;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemDataSet
    {    
        public TestPlanCreation TestPlan { get; set; }
        public IEnumerable<TestCaseCreation> TestCases { get; set; }   
    }
}
