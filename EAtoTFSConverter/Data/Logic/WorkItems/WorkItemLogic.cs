﻿using System;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System.Collections.Generic;
using System.Linq;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    class WorkItemLogic
    {
        private Project Project { get; }
        private ComparerItemsFactory ComparerItemsFactory { get; set; }
        private DatabaseOperations DbOperations { get; set; }
        private WorkItemDataSet WorkItemDataSet { get; set; } = new WorkItemDataSet();

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
            GenerateTestSuites();
        }

        private void GenerateTestPlan()
        {
            if (!DbOperations.CheckWorkItem(Project.Id, WorkItemType.TestPlan))
            {
                CreateTestPlanMessageDraft();
                SendMessages(WorkItemDataSet.TestPlan);
            }
            else
            {

            }
        }

        private void CreateTestPlanMessageDraft()
        {
            
        }

        private void GenerateTestSuites()
        {
            CreateTestSuiteMessageDrafts();
            SendMessages(WorkItemDataSet.TestSuite);
        }

        private void GenerateTestCases()
        {
            Compare();
            CreateTestCaseMessageDrafts();
            SendMessages(WorkItemDataSet.TestCases);
        }
        private void CreateTestSuiteMessageDrafts()
        {
            
        }

        private void CreateTestCaseMessageDrafts()
        {
            if (WorkItemDataSet.TestComparisionResults != null)
                foreach (var item in WorkItemDataSet.TestComparisionResults)
                {
                    WorkItemDataSet.TestCases.Add(MessageFactory.BuildMessage(item));
                }
        }
        private async void SendMessages(IEnumerable<IWorkItemBase> messages)
        {
            APICommunication api = new APICommunication(Project);
            if (messages != null)
                foreach (var message in messages)
                {
                    await api.SendMessage(message);
                }
        }

        private void Compare()
        {
            if (_activeEAscenarios != null)
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
                                    DbOperations.getStep(step.PreviousVersionId)),
                                WorkItemType.TestStep,
                                step.Id);

                            var result = comparer.GetComparisionResult(stepData);

                            stepsResult.Add(result);
                        }

                    scenarioResult = AnalizeComparision(scenarioResult, stepsResult);
                    WorkItemDataSet.TestComparisionResults.Add(scenarioResult);
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
