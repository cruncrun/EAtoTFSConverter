using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    public static class MessageFactory
    {
        private static DatabaseOperations DbOperations { get; set; }

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

        private static IWorkItemBase BuildTestCaseMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.UseExisting:
                    var existingData = GetExistingData(result);
                    var creationData = new WorkItemCreationData
                    {
                        Guid = result.Guid,
                        WorkItemId = existingData.WorkItemId
                    };
                    creationData.WorkItemBaseData.Json = existingData.Value; // sprawdzić, czy to dobra kolumna :)
                    return creationData;

                case OperationType.CreateNew:
                    var json = GenerateNewJson(result);
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    // wysyłka komunikatu i zapis danych
                    // pobranie workItema (IWorkItemBase) z odpowiednim ID
                    // przekazanie do wykorzystania
                    return new TestCaseCreation();
                case OperationType.Update:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    // wysyłka komunikatu i zapis danych
                    // pobranie workItema (IWorkItemBase) z odpowiednim ID
                    // przekazanie do wykorzystania
                    return new TestCaseCreation();
                case OperationType.Delete:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    return new TestCaseCreation();
                default:
                    return null;
            }
        }

        private static string GenerateNewJson(ComparisionResult result)
        {
            string json = "json";

            return json;
        }

        private static WorkItem GetExistingData(ComparisionResult result)
        {
            return DbOperations.GetWorkItem(result.Guid);
        }

        private static IWorkItemBase BuildTestSuiteMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.CreateNew:
                    return new TestSuiteCreation();
                case OperationType.Update:
                case OperationType.UseExisting:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }

        private static IWorkItemBase BuildTestPlanMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.UseExisting:
                    return new TestPlanCreation();
                case OperationType.CreateNew:
                    return new TestPlanCreation();
                case OperationType.Update:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }
    }
}
