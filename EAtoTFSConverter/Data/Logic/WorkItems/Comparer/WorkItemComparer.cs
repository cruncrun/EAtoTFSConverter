using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class WorkItemComparer
    {
        private ComparerItemsFactory ComparerItemsFactory { get; set; }
        private IComparable ActiveEntity { get; set; }
        private IComparable PreviousEntity { get; set; }
        public ComparisionResult Result { get; set; }

        public WorkItemComparer(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            Result = new ComparisionResult(workItemType);
        }

        public WorkItemComparer()
        {

        }

        public ComparisionResult GetComparisionResult()
        {
            //Compare(ActiveEntity, PreviousEntity);
            return Result;
        }

        public ComparisionResult GetComparisionResult(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType, Guid id)
        {
            return Compare(activeEntity, previousEntity, workItemType, id);
        }

        private ComparisionResult Compare(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType, Guid id)
        {
            var comparisionResult = new ComparisionResult(workItemType, id);

            if (activeEntity == null && previousEntity != null)
            {
                comparisionResult.OperationType = OperationType.Delete;
                comparisionResult.Result = false;
                return comparisionResult;
            }

            if (activeEntity != null && previousEntity == null)
            {
                comparisionResult.OperationType = OperationType.CreateNew;
                comparisionResult.Result = false;
                return comparisionResult;
            }

            if (CompareData(activeEntity, previousEntity))
            {
                comparisionResult.OperationType = OperationType.UseExisting;
                comparisionResult.Result = true;
                return comparisionResult;
            }

            return new ComparisionResult
            {
                WorkItemType = workItemType,
                OperationType = OperationType.Update,
                Result = false, 
                Guid = id
            };
        }

        private bool CompareData(IComparable activeEntity, IComparable previousEntity)
        {
            return CompareValues(activeEntity?.Name, previousEntity?.Name)
                   && CompareValues(activeEntity?.Description, previousEntity?.Description)
                   && CompareValues(activeEntity?.Level, previousEntity?.Level)
                   && CompareValues(activeEntity?.Result, previousEntity?.Result);
        }

        private bool CompareValues<T>(T active, T previous) => active?.ToString() == previous?.ToString();
    }
}
