using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    internal static class MessageFactory
    {
        private static DatabaseOperations DbOperations { get; set; } = new DatabaseOperations();

        public static IWorkItemBase BuildMessage(ComparisionResult result)
        {
            switch (result.WorkItemType)
            {
                case WorkItemType.TestPlan:
                    return BuildTestPlanMessage(result);

                case WorkItemType.TestSuite:
                    return BuildTestSuiteMessage(result);

                case WorkItemType.TestCase:
                    return BuildTestCaseMessage(result);

                default:
                    return null;
            }
        }

        #region TestCase

        private static IWorkItemBase BuildTestCaseMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.UseExisting:
                    return GetExistingTestCaseData(result);

                case OperationType.CreateNew:
                    return CreateNewTestCaseData(result);

                case OperationType.Update:
                    return CreateUpdatedTestCaseData(result);

                case OperationType.Delete:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    return new WorkItemCreationData();
                default:
                    return null;
            }
        }

        private static IWorkItemBase CreateUpdatedTestCaseData(ComparisionResult result)
        {
            return CreateNewTestCaseData(result);
        }

        private static IWorkItemBase CreateNewTestCaseData(ComparisionResult result)
        {
            var scenarioData = DbOperations.getEAscenario(result.Guid);

            var data = new[] {
                new WorkItemBaseDataTestCase
                {
                Op = "add",
                Path = "/fields/System.Title",
                Value = scenarioData.Name
                },
                new WorkItemBaseDataTestCase()
                {
                Op = "add",
                Path = "/fields/Microsoft.VSTS.TCM.Steps",
                Value = GenerateNewTestCaseJson(result)
                }
            }; 

            var creationData = new WorkItemCreationData
            {
                Guid = result.Guid,
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json-patch+json")
            };

            return creationData;
        }

        private static IWorkItemBase GetExistingTestCaseData(ComparisionResult result)
        {
            var existingData = GetExistingData(result);
            var creationData = new WorkItemCreationData
            {
                Guid = result.Guid,
                WorkItemId = existingData.WorkItemId,
                WorkItemBaseData = new WorkItemBaseDataTestCase
                {
                    Value = existingData.Value
                }
            };

            return creationData;
        }

        private static string GenerateNewTestCaseJson(ComparisionResult result)
        {
            var steps = DbOperations.GetActive_Steps(result.Guid);
            return GenerateStepsXml(steps);
        }

        private static string GenerateStepsXml(IEnumerable<active_Step> steps)
        {
            var xml = new StringBuilder();
            var activeSteps = steps.ToList();
            xml.Append($"<steps id=\"0\">");
            foreach (var step in activeSteps)
            {
                xml.Append($"<step id=\"{step.Level}\" type=\"ValidateStep\">" +
                           "<parameterizedString isformatted=\"true\">" +
                           $"{step.Name}</parameterizedString>" +
                           "<parameterizedString isformatted=\"true\">" +
                           $"{step.Name}></parameterizedString>" +
                           "<description/></step >");
            }
            xml.Append("</steps>");
            return xml.ToString();
        }

        #endregion

        #region TestSuite

        private static IWorkItemBase BuildTestSuiteMessage(ComparisionResult result)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            switch (result.OperationType)
            {
                case OperationType.CreateNew:
                    return CreateNewTestSuiteData();
                case OperationType.Update:
                case OperationType.UseExisting:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }

        private static IWorkItemBase CreateNewTestSuiteData()
        {
            return new WorkItemCreationData();
        }

        #endregion

        #region TestPlan

        private static IWorkItemBase BuildTestPlanMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.CreateNew:
                    return CreateNewTestPlanData(result); 
                case OperationType.UseExisting:
                case OperationType.Update:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }

        private static IWorkItemBase CreateNewTestPlanData(ComparisionResult result)
        {
            var data = new WorkItemBaseDataTestPlan()
            {
                Name = "Plan testów z aplikacji desktopowej",
                Description = "Opis planu testów z apki"
            };

            return new WorkItemCreationData
            {
                WorkItemType = WorkItemType.TestPlan,
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"),
                ApiAddress =
                    "https://dev.azure.com/crunchips/EA-TFS_Conversion/_apis/test/plans?api-version=5.0"
            };
        }

        #endregion


        private static WorkItem GetExistingData(ComparisionResult result)
        {
            return DbOperations.GetWorkItem(result.Guid);
        }
    }
}
