using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using static System.String;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    internal class WorkItemLogic
    {
        private Project Project { get; }
        private ComparerItemsFactory ComparerItemsFactory { get; }
        private DatabaseOperations DbOperations { get; }
        private WorkItemDataSet WorkItemDataSet { get; } = new WorkItemDataSet();

        private readonly IEnumerable<active_EAscenario> _activeEAscenarios;
        private readonly IEnumerable<active_Step> _activeSteps;

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
            GenerateTestPlan();
            GenerateTestCases();
            //GenerateTestSuites();
        }

        #region TestPlan

        private void GenerateTestPlan()
        {
            var testPlan = new ComparisionResult(WorkItemType.TestPlan)
            {
                Result = DbOperations.CheckWorkItem(Project.Id, WorkItemType.TestPlan)
            };

            try
            {
                if (!testPlan.Result)
                {
                    testPlan.OperationType = OperationType.CreateNew;
                    CreateTestPlanMessageDraft(testPlan);
                    SendMessages(WorkItemDataSet.TestPlan);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

        }

        private void CreateTestPlanMessageDraft(ComparisionResult testPlan)
        {
            try
            {
                var message = MessageFactory.BuildMessage(testPlan);
               // message.ApiAddress = Project.Address + "_apis/test/plans?api-version=5.0";
                message.Project = Project;
                WorkItemDataSet.TestPlan.Add(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        #endregion

        #region TestCases

        private void GenerateTestCases()
        {
            Compare();
            CreateTestCaseMessageDrafts();
            SendMessages(WorkItemDataSet.TestCases);
        }

        private void CreateTestCaseMessageDrafts()
        {
            try
            {
                if (WorkItemDataSet.TestComparisionResults != null)
                    foreach (var item in WorkItemDataSet.TestComparisionResults)
                    {
                        var message = MessageFactory.BuildMessage(item);
                        message.Project = Project;
                        message.ApiAddress = Project.Address + "_apis/wit/workitems/$Test%20Case?api-version=5.1";
                        WorkItemDataSet.TestCases.Add(message);
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            
        }

        private void Compare()
        {
            if (_activeEAscenarios != null)
                try
                {
                    foreach (var scenario in _activeEAscenarios)
                    {
                        var stepsResult = new List<ComparisionResult>();
                        WorkItemComparer comparer = new WorkItemComparer();

                        var scenarioData = new ComparisionDataSet(
                            ComparerItemsFactory.MapToComparsionEntity(scenario),
                            ComparerItemsFactory.MapToComparsionEntity(
                                DbOperations.getEAscenario(scenario.PreviousVersionId)),
                            WorkItemType.TestCase,
                            scenario.Id);

                        var scenarioResult = comparer.GetComparisionResult(scenarioData);

                        var scenarioSteps = GetStepsForScenario(scenario);

                        if (scenarioSteps != null)
                            foreach (var step in scenarioSteps)
                            {
                                var stepData = new ComparisionDataSet(
                                    ComparerItemsFactory.MapToComparsionEntity(step),
                                    ComparerItemsFactory.MapToComparsionEntity(
                                        DbOperations.GetStep(step.PreviousVersionId)),
                                    WorkItemType.TestStep,
                                    step.Id);

                                var result = comparer.GetComparisionResult(stepData);

                                stepsResult.Add(result);
                            }

                        scenarioResult = AnalizeComparision(scenarioResult, stepsResult);
                        WorkItemDataSet.TestComparisionResults.Add(scenarioResult);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(
                        "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
        }

        private IOrderedEnumerable<active_Step> GetStepsForScenario(active_EAscenario scenario)
        {
            return _activeSteps
                .Where(w => scenario.Id == w.EAScenarioId)
                .Select(s => s)
                .OrderBy(o => o.Level);
        }

        private static ComparisionResult AnalizeComparision(ComparisionResult scenarioResult, List<ComparisionResult> stepsResult)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        #endregion

        #region TestSuite

        private void GenerateTestSuites()
        {
            CreateTestSuiteMessageDrafts();
            SendMessages(WorkItemDataSet.TestSuite);
        }
        private void CreateTestSuiteMessageDrafts()
        {
            try
            {
                var testSuite = new ComparisionResult(WorkItemType.TestSuite) { OperationType = OperationType.CreateNew };
                var message = MessageFactory.BuildMessage(testSuite);
                message.ApiAddress = PrepareTestSuiteAddress();
                message.Project = Project;
                WorkItemDataSet.TestSuite.Add(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        private string PrepareTestSuiteAddress()
        {
            var baseAddress = DbOperations.GetUriAddress(Project);
            var testCaseIds = DbOperations.GetWorkItems(Project.Id, WorkItemType.TestCase);
            var testCases = Join(",", testCaseIds);
            var fullAddress = baseAddress + "_apis/test/Plans/"
                                          + DbOperations.GetWorkItem(Project.Id, WorkItemType.TestPlan)
                                          + "/suites/" 
                                          + DbOperations.GetWorkItem(Project.Id, WorkItemType.TestSuite)
                                          + "/testcases/"
                                          + testCases + "?api-version=5.0";
            return fullAddress;
        }

        #endregion

        private async void SendMessages(IEnumerable<IWorkItemBase> messages)
        {
            try
            {
                ApiCommunication api = new ApiCommunication(Project);
                if (messages != null)
                    foreach (var message in messages)
                    {
                        await api.SendMessage(message);
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            
        }
    }
}

