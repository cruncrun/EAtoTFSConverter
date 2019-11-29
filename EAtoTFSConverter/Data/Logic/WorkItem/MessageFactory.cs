using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    public static class MessageFactory
    {
        public static IWorkItemBase BuildMessage(WorkItemType workItemType, OperationType operationType, IWorkItemBase CreationData)
        {
            switch (workItemType)
            {
                case WorkItemType.TestPlan:
                    return BuildTestPlanMessage(operationType, CreationData);
                    
                case WorkItemType.TestSuite:
                    return BuildTestSuiteMessage(operationType, CreationData);

                case WorkItemType.TestCase:
                    return BuildTestCaseMessage(operationType, CreationData);

                default:
                    return null;
            }
        }

        private static IWorkItemBase BuildTestCaseMessage(OperationType operationType, IWorkItemBase CreationData)
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

        private static IWorkItemBase BuildTestSuiteMessage(OperationType operationType, IWorkItemBase CreationData)
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

        private static IWorkItemBase BuildTestPlanMessage(OperationType operationType, IWorkItemBase CreationData)
        {
            switch (operationType)
            {
                case OperationType.UseExisting:
                    return new TestPlanCreationData(CreationData.WorkItemId);
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
