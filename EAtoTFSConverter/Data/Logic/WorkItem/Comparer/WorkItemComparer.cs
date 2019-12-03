using System.Web.Compilation;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    public class WorkItemComparer
    {
        private IComparable ActiveEntity { get; set; }
        private IComparable PreviousEntity { get; set; }
        public ComparsionResult Result { get; set; }

        public WorkItemComparer(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            Result = new ComparsionResult(workItemType);
        }

        public WorkItemComparer()
        {
                
        }

        public ComparsionResult GetComparsionResult()
        {
            //Compare(ActiveEntity, PreviousEntity);
            return Result;
        }

        public ComparsionResult GetComparsionResult(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            return Compare(activeEntity, previousEntity, workItemType);
        }

        private ComparsionResult Compare(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            if (activeEntity == null && previousEntity != null)
            {
                return new ComparsionResult
                {
                    WorkItemType = workItemType,
                    OperationType = OperationType.Delete,
                    Result = false
                };
            }

            if (activeEntity != null && previousEntity == null)
            {
                return new ComparsionResult
                {
                    WorkItemType = workItemType,
                    OperationType = OperationType.CreateNew,
                    Result = false
                };
            }

            var comparsionResult = CompareValues(activeEntity?.Name, previousEntity?.Name) &&
                                   CompareValues(activeEntity?.Description, previousEntity?.Description) &&
                                   CompareValues(activeEntity?.Level, previousEntity?.Level) &&
                                   CompareValues(activeEntity?.Result, previousEntity?.Result);

            if (comparsionResult)
            {
                return new ComparsionResult
                {
                    WorkItemType = workItemType,
                    OperationType = OperationType.UseExisting,
                    Result = true
                };
            }
            else
            {
                return new ComparsionResult
                {
                    WorkItemType = workItemType,
                    OperationType = OperationType.Update,
                    Result = false
                };
            }
        }

        private bool CompareValues<T>(T active, T previous)
        {
            return active?.ToString() == previous?.ToString();
        }
    }
}
