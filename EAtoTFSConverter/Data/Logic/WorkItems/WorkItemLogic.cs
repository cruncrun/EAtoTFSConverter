using System.Collections.Generic;
using System.Linq;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    class WorkItemLogic
    {
        private Project Project { get; }
        private ComparerItemsFactory ComparerItemsFactory { get; set; }
        private DatabaseOperations DbOperations { get; set; }

        private readonly IEnumerable<active_EAscenario> _activeEAscenarios;
        private readonly IEnumerable<active_Step> _activeSteps;
        private readonly List<ComparsionResult> _newWorkItems = new List<ComparsionResult>();
        private readonly List<IWorkItemBase> messages = new List<IWorkItemBase>();

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
            Compare();
            CreateMessageDrafts();
            SendMessages();


            WorkItemDataSet workItemDataSet = new WorkItemDataSet
            {
                Project = Project,
                TestPlan = new WorkItemCreationLogic(Project, WorkItemType.TestPlan),
                TestCases = null
            };

            workItemDataSet.TestPlan.Prepare();
        }

        private async void SendMessages()
        {
            APICommunication api = new APICommunication(Project);
            foreach (var message in messages)
            {
                await api.SendAsync(message);
            }
        }

        private void CreateMessageDrafts()
        {
            foreach (var item in _newWorkItems)
            {
                messages.Add(MessageFactory.BuildMessage(item.WorkItemType, item.OperationType));
            }
        }

        private void Compare()
        {
            foreach (var scenario in _activeEAscenarios)
            {
                var stepsResult = new List<ComparsionResult>();
                WorkItemComparer comparer = new WorkItemComparer();

                var scenarioResult = comparer.GetComparsionResult(
                    ComparerItemsFactory.MapToComparsionEntity(scenario),
                    ComparerItemsFactory.MapToComparsionEntity(DbOperations.getEAscenario(scenario.PreviousVersionId)),
                    WorkItemType.TestCase);

                var scenarioSteps = GetStepsForScenario(scenario);

                foreach (var step in scenarioSteps)
                {
                    stepsResult.Add(comparer.GetComparsionResult(
                        ComparerItemsFactory.MapToComparsionEntity(step),
                        ComparerItemsFactory.MapToComparsionEntity(DbOperations.getStep(step.PreviousVersionId)),
                        WorkItemType.TestStep));
                }

                scenarioResult = ComparsionAnalysis(scenarioResult, stepsResult);

                if (!scenarioResult.Result)
                {
                    _newWorkItems.Add(scenarioResult);
                }
            }
        }

        private IOrderedEnumerable<active_Step> GetStepsForScenario(active_EAscenario scenario)
        {
            return _activeSteps
                .Where(w => scenario.Id == w.EAScenarioId)
                .Select(s => s)
                .OrderBy(o => o.Level);
        }

        private ComparsionResult ComparsionAnalysis(ComparsionResult scenarioResult, List<ComparsionResult> stepsResult)
        {
            if (scenarioResult.Result && stepsResult.All(s => s.Result))
            {
                return scenarioResult;
            }

            if (scenarioResult.Result && stepsResult.Any(s => !s.Result))
            {
                scenarioResult.Result = false;
                scenarioResult.OperationType = OperationType.Update;
                return scenarioResult;
            }

            if (!scenarioResult.Result && stepsResult.Any(s => s.Result))
            {
                scenarioResult.Result = false;
                scenarioResult.OperationType = OperationType.Update;
                return scenarioResult;
            }

            return scenarioResult;
        }
    }
}
