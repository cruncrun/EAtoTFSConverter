using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;
using EAtoTFSConverter.Data.Logic.WorkItems.Comparer;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    public static class MessageFactory
    {
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
                    // pobranie workItema (IWorkItemBase) z odpowiednim ID
                    // przekazanie do wykorzystania
                    return new TestCaseCreationData();
                case OperationType.CreateNew:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    // wysyłka komunikatu i zapis danych
                    // pobranie workItema (IWorkItemBase) z odpowiednim ID
                    // przekazanie do wykorzystania
                    return new TestCaseCreationData();
                case OperationType.Update:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    // wysyłka komunikatu i zapis danych
                    // pobranie workItema (IWorkItemBase) z odpowiednim ID
                    // przekazanie do wykorzystania
                    return new TestCaseCreationData();
                case OperationType.Delete:
                    // wygenerowanie IWorkItemBase z active_scenario i powiązanych active_steps
                    return new TestCaseCreationData();
                default:
                    return null;
            }
        }

        private static IWorkItemBase BuildTestSuiteMessage(ComparisionResult result)
        {
            switch (result.OperationType)
            {
                case OperationType.CreateNew:
                    return new TestSuiteCreationData();
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
                    return new TestPlanCreationData();
                case OperationType.CreateNew:
                    return new TestPlanCreationData();
                case OperationType.Update:
                case OperationType.Delete:
                    throw new InvalidOperationException();
                default:
                    return null;
            }
        }
    }
}
