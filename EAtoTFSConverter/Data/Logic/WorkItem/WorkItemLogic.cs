using System.Linq;
using System.Windows.Forms;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;
using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemLogic
    {
        public Project Project { get; set; }

        public WorkItemLogic(Project selectedProject)
        {
            Project = selectedProject;
        }

        internal void PrepareData()
        {
            WorkItemDataSet workItemDataSet = new WorkItemDataSet();
            workItemDataSet.TestPlan = new TestPlanCreation();
            workItemDataSet.TestCases = null;
        } 
    }
}
