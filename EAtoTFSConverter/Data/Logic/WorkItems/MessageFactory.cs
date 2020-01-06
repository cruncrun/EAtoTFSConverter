using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    internal static class MessageFactory
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
            // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
            // wysyłka komunikatu i zapis danych
            // pobranie workItema (IWorkItemBase) z odpowiednim ID
            // przekazanie do wykorzystania
            //throw new NotImplementedException();

            return new WorkItemCreationData();
            
        }

        private static IWorkItemBase CreateNewTestCaseData(ComparisionResult result)
        {
            var creationData = new WorkItemCreationData
            {
                Guid = result.Guid,
                WorkItemBaseData =
                {
                    Json = GenerateNewTestCaseJson(result)
                }
            };
            // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
            // wysyłka komunikatu i zapis danych
            // pobranie workItema (IWorkItemBase) z odpowiednim ID
            // przekazanie do wykorzystania


            return creationData;
        }

        private static IWorkItemBase GetExistingTestCaseData(ComparisionResult result)
        {
            var existingData = GetExistingData(result);
            var creationData = new WorkItemCreationData
            {
                Guid = result.Guid,
                WorkItemId = existingData.WorkItemId,
                WorkItemBaseData =
                {
                    Json = existingData.Value // sprawdzić, czy to dobra kolumna :)
                }
            };

            return creationData;
        }

        private static string GenerateNewTestCaseJson(ComparisionResult result)
        {
            var steps = DbOperations.GetActive_Steps(result.Guid);
            //  przygotowanie jsona w oparciu o kroki
            string json = "json";

            return json;
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
            var creationData = new WorkItemCreationData
            {

            };

            return creationData;
        }

        #endregion

        #region TestPlan

        private static IWorkItemBase BuildTestPlanMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.UseExisting:
                    return new WorkItemCreationData();
                case OperationType.CreateNew:
                    return new WorkItemCreationData();
                case OperationType.Update:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }

        #endregion


        private static WorkItem GetExistingData(ComparisionResult result)
        {
            return DbOperations.GetWorkItem(result.Guid);
        }




    }
}
