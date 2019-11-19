using System.Linq;
using System.Threading.Tasks;
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

        internal async Task PrepareData()
        {
            WorkItemDataSet workItemDataSet = new WorkItemDataSet
            {
                Project = Project,
                TestPlan = new TestPlanCreation(Project),
                TestCases = null
            };

            workItemDataSet.TestPlan.Prepare();
        } 
    }
}
