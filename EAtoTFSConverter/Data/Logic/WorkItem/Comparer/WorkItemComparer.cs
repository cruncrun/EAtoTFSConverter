using System.Web.Compilation;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class WorkItemComparer
    {
        public IComparable ActiveEntity { get; set; }
        public IComparable PreviousEntity { get; set; }
        public bool ComparsionResult { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }

        public WorkItemComparer(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            WorkItemType = workItemType;
            ComparsionResult = Compare(ActiveEntity, PreviousEntity);
        }

        private bool Compare(IComparable activeEntity, IComparable previousEntity)
        {
            bool comparsionResult;
            if (activeEntity == null && previousEntity != null)
            {
                OperationType = OperationType.Delete;
                comparsionResult = false;
                return comparsionResult;
            }

            if (activeEntity != null && previousEntity == null)
            {
                OperationType = OperationType.CreateNew;
                comparsionResult = false;
                return comparsionResult;
            }

            comparsionResult = CompareValues(activeEntity?.Name, previousEntity?.Name) &&
                               CompareValues(activeEntity?.Description, previousEntity?.Description) &&
                               CompareValues(activeEntity?.Level, previousEntity?.Level) &&
                               CompareValues(activeEntity?.Result, previousEntity?.Result);

            if (comparsionResult)
            {
                OperationType = OperationType.UseExisting;
                return comparsionResult;
            }
            else
            {
                OperationType = OperationType.Update;
                return comparsionResult;
            }
        }

        private bool CompareValues<T>(T active, T previous)
        {
            return active?.ToString() == previous?.ToString();
        }
    }
}
