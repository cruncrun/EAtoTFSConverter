using System.Collections.Generic;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    internal class WorkItemDataSet
    {
        public WorkItemDataSet()
        {
            TestPlan = new List<IWorkItemBase>();
            TestSuite = new List<IWorkItemBase>();
            TestCases = new List<IWorkItemBase>();
        }

        public List<IWorkItemBase> TestPlan { get; set; }
        public List<IWorkItemBase> TestSuite { get; set; }
        public List<IWorkItemBase> TestCases { get; set; }
        public List<ComparisionResult> TestComparisionResults { get; set; } = new List<ComparisionResult>();
    }
}