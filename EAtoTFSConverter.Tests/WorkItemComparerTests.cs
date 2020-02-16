using EAtoTFSConverter.Data.Logic.WorkItems;
using Xunit;

namespace EAtoTFSConverter.Tests
{
    public class WorkItemComparerTests
    {
        [Fact]
        public void ScenarioUpdate()
        {
            ComparisionEntity activeScenario = new ComparisionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparisionEntity previouScenario = new ComparisionScenario()
            {
                Description = "bbb",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparisionResult receivedResult = wic.GetComparisionResult();
            ComparisionResult expectedResult = new ComparisionResult();
            expectedResult.OperationType = OperationType.Update;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioUseExisting()
        {
            ComparisionEntity activeScenario = new ComparisionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparisionEntity previouScenario = new ComparisionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparisionResult receivedResult = wic.GetComparisionResult();
            ComparisionResult expectedResult = new ComparisionResult();
            expectedResult.OperationType = OperationType.UseExisting;
            expectedResult.Result = true;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioDelete()
        {
            ComparisionEntity activeScenario = null;
            ComparisionEntity previouScenario = new ComparisionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparisionResult receivedResult = wic.GetComparisionResult();
            ComparisionResult expectedResult = new ComparisionResult();
            expectedResult.OperationType = OperationType.Delete;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }

        [Fact]
        public void ScenarioCreateNew()
        {
            ComparisionEntity activeScenario = new ComparisionScenario()
            {
                Description = "aaa",
                Guid = null,
                Level = null,
                Name = "Scenariusz 1",
                Result = null
            };
            ComparisionEntity previouScenario = null;

            WorkItemComparer wic = new WorkItemComparer(activeScenario, previouScenario, WorkItemType.TestCase);

            ComparisionResult receivedResult = wic.GetComparisionResult();
            ComparisionResult expectedResult = new ComparisionResult();
            expectedResult.OperationType = OperationType.CreateNew;
            expectedResult.Result = false;
            expectedResult.WorkItemType = WorkItemType.TestCase;


            Assert.Equal(expectedResult.Result, receivedResult.Result);
            Assert.Equal(expectedResult.OperationType == OperationType.Update, receivedResult.OperationType == OperationType.Update);
        }
    }
}
