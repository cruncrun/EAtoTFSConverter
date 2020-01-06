using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System.Collections.Generic;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    internal class WorkItemDataSet
    {
        public Project Project { get; set; }
        public List<IWorkItemBase> TestPlan { get; set; }
        public List<IWorkItemBase> TestSuite { get; set; }
        public List<IWorkItemBase> TestCases { get; set; }
        public List<ComparisionResult> TestComparisionResults { get; set; } = new List<ComparisionResult>();

        public WorkItemDataSet()
        {
            TestSuite = new List<IWorkItemBase>();
            TestCases = new List<IWorkItemBase>();
        }
    }
}
