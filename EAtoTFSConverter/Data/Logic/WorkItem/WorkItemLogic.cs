using System.Collections.Generic;
using System.Linq;
using EAtoTFSConverter.Data.Logic.WorkItem.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemLogic
    {
        private Project Project { get; }
        private ComparerItemsFactory ComparerItemsFactory { get; set; }
        private DatabaseOperations DbOperations { get; set; }
        private IEnumerable<active_EAscenario> _activeEAscenarios = new List<active_EAscenario>();
        private IEnumerable<active_Step> _activeSteps = new List<active_Step>();

        private ComparedDataSet activeItemsDataSet = new ComparedDataSet();

        public WorkItemLogic(Project selectedProject)
        {
            Project = selectedProject;
            ComparerItemsFactory = new ComparerItemsFactory();
            DbOperations = new DatabaseOperations();
            _activeEAscenarios = DbOperations.GetActive_EAscenarios(Project);
            _activeSteps = DbOperations.GetActive_Steps();
        }

        internal void PrepareData()
        {
            activeItemsDataSet = ComparerItemsFactory.CreateDataSet(_activeEAscenarios, _activeSteps);
            


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
