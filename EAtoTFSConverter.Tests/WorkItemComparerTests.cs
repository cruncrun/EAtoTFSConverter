using EAtoTFSConverter.Data.Logic.WorkItem;
using EAtoTFSConverter.Data.Logic.WorkItem.Comparer;
using Xunit;

namespace EAtoTFSConverter.Tests
{
    public class WorkItemComparerTests
    {
        [Fact]
        public void ScenarioUpdate()
        {
            ComparsionEntity activeScenario = new ComparsionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparsionEntity previouScenario = new ComparsionScenario()
            {
                Description = "bbb",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparsionResult receivedResult = wic.GetComparsionResult();
            ComparsionResult expectedResult = new ComparsionResult();
            expectedResult.OperationType = OperationType.Update;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioUseExisting()
        {
            ComparsionEntity activeScenario = new ComparsionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparsionEntity previouScenario = new ComparsionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparsionResult receivedResult = wic.GetComparsionResult();
            ComparsionResult expectedResult = new ComparsionResult();
            expectedResult.OperationType = OperationType.UseExisting;
            expectedResult.Result = true;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioDelete()
        {
            ComparsionEntity activeScenario = null;
            ComparsionEntity previouScenario = new ComparsionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparsionResult receivedResult = wic.GetComparsionResult();
            ComparsionResult expectedResult = new ComparsionResult();
            expectedResult.OperationType = OperationType.Delete;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioCreateNew()
        {
            ComparsionEntity activeScenario = new ComparsionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparsionEntity previouScenario = null;

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparsionResult receivedResult = wic.GetComparsionResult();
            ComparsionResult expectedResult = new ComparsionResult();
            expectedResult.OperationType = OperationType.CreateNew;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }
    }
}
