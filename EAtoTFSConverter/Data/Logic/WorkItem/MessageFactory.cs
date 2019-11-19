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
        public static IWorkItemBase BuildMessage(WorkItemType workItemType, OperationType operationType)
        {
            switch (workItemType)
            {
                case WorkItemType.TestPlan:
                    switch (operationType)
                    {
                        case OperationType.UseExisting:
                            return new TestPlanCreationData();
                        case OperationType.CreateNew:
                            return new TestPlanCreationData(); 
                        case OperationType.Update:
                            return new TestPlanCreationData();
                        case OperationType.Delete:
                            return new TestPlanCreationData();
                        default:
                            return null;
                    }
                    
                case WorkItemType.TestSuite:
                    switch (operationType)
                    {
                        case OperationType.UseExisting:
                            return new TestSuiteCreationData();
                        case OperationType.CreateNew:
                            return new TestSuiteCreationData();
                        case OperationType.Update:
                            return new TestSuiteCreationData();
                        case OperationType.Delete:
                            return new TestSuiteCreationData();
                        default:
                            return null;
                    }

                case WorkItemType.TestCase:
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

                default:
                    return null;

            }
        }
    }
}
