using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAtoTFSConverter.Data.Logic.WorkItem.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;
using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemLogic
    {
        private Project Project { get; }
        private ComparerFactory ComparerFactory { get; set; }
        private IEnumerable<active_EAscenario> activeEAscenarios = new List<active_EAscenario>();
        private IEnumerable<active_Step> activeSteps = new List<active_Step>();

        public WorkItemLogic(Project selectedProject)
        {
            Project = selectedProject;
            ComparerFactory = new ComparerFactory();
        }

        internal void PrepareData()
        {
            WorkItemDataSet workItemDataSet = new WorkItemDataSet
            {
                Project = Project,
                TestPlan = new WorkItemCreationLogic(Project, WorkItemType.TestPlan),
                TestCases = null
            };

            workItemDataSet.TestPlan.Prepare();
        } 
    }
}
