namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class WorkItemComparer
    {
        private ComparerItemsFactory ComparerItemsFactory { get; set; }

        private IComparable ActiveEntity { get; }

        private IComparable PreviousEntity { get; }

        public ComparisionResult Result { get; set; }
        public ComparisionDataSet DataSet { get; set; }

        public WorkItemComparer(IComparable activeEntity, IComparable previousEntity, WorkItemType workItemType)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            Result = new ComparisionResult(workItemType);
        }

        public WorkItemComparer(ComparisionDataSet data)
        {
            DataSet = data;
            Result = Compare(DataSet);
        }

        public WorkItemComparer()
        {

        }

        public ComparisionResult GetComparisionResult(ComparisionDataSet data)
        {
            return Compare(data);
        }

        private ComparisionResult Compare(ComparisionDataSet data)
        {
            var comparisionResult = new ComparisionResult(data.WorkItemType, data.Guid);

            if (CheckForDelete(data))
            {
                comparisionResult.OperationType = OperationType.Delete;
                comparisionResult.Result = false;
                return comparisionResult;
            }

            if (CheckForCreate(data))
            {
                comparisionResult.OperationType = OperationType.CreateNew;
                comparisionResult.Result = false;
                return comparisionResult;
            }

            if (CompareData(data.ActiveEntity, data.PreviousEntity))
            {
                comparisionResult.OperationType = OperationType.UseExisting;
                comparisionResult.Result = true;
                return comparisionResult;
            }

            return new ComparisionResult
            {
                WorkItemType = data.WorkItemType,
                OperationType = OperationType.Update,
                Result = false,
                Guid = data.Guid
            };
        }

        private static bool CheckForDelete(ComparisionDataSet data)
        {
            return data.ActiveEntity == null && data.PreviousEntity != null;
        }

        public bool CheckForCreate(ComparisionDataSet data)
        {
            return data.ActiveEntity != null && data.PreviousEntity == null;
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
