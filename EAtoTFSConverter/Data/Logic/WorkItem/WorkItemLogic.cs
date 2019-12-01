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
        private IEnumerable<active_EAscenario> _activeEAscenarios;
        private IEnumerable<active_Step> _activeSteps;

        private List<WorkItemComparer> compares = new List<WorkItemComparer>();
        private List<IWorkItemBase> messages = new List<IWorkItemBase>();

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
            foreach (var scenario in _activeEAscenarios)
            {
                compares.Add(new WorkItemComparer(
                    ComparerItemsFactory.MapToComparsionEntity(scenario),
                    ComparerItemsFactory.MapToComparsionEntity(DbOperations.getEAscenario(scenario.PreviousVersionId)),
                    WorkItemType.TestCase));
            }

            foreach (var step in _activeSteps)
            {
                compares.Add(new WorkItemComparer(
                    ComparerItemsFactory.MapToComparsionEntity(step),
                    ComparerItemsFactory.MapToComparsionEntity(DbOperations.getStep(step.PreviousVersionId)),
                    WorkItemType.TestStep));
            }

            foreach (var item in compares)
            {
                MessageFactory.BuildMessage(item.WorkItemType, item.OperationType);
            }

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
