using System;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItems
{
    public static class MessageFactory
    {
        public static IWorkItemBase BuildMessage(WorkItemType workItemType, OperationType operationType)
        {
            switch (workItemType)
            {
                case WorkItemType.TestPlan:
                    return BuildTestPlanMessage(operationType);

                case WorkItemType.TestSuite:
                    return BuildTestSuiteMessage(operationType);

                case WorkItemType.TestCase:
                    return BuildTestCaseMessage(operationType);

                default:
                    return null;
            }
        }

        private static IWorkItemBase BuildTestCaseMessage(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.UseExisting:
                    return new TestCaseCreationData();
                case OperationType.CreateNew:
                    return new TestCaseCreationData();
                case OperationType.Update:
                    return new TestCaseCreationData();
                case OperationType.Delete:
                    return new TestCaseCreationData();
                default:
                    return null;
            }
        }

        private static IWorkItemBase BuildTestSuiteMessage(OperationType operationType)
        {
            switch (operationType)
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

        private static IWorkItemBase BuildTestPlanMessage(OperationType operationType)
        {
            switch (operationType)
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
