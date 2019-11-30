namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class WorkItemComparer
    {
        public IComparable ActiveEntity { get; set; }
        public IComparable PreviousEntity { get; set; }
        public bool ComparsionResult { get; set; }
        public OperationType OperationType { get; set; }

        public WorkItemComparer(IComparable activeEntity, IComparable previousEntity)
        {
            ActiveEntity = activeEntity;
            PreviousEntity = previousEntity;
            ComparsionResult = Compare(ActiveEntity, PreviousEntity);
        }

        private bool Compare(IComparable activeEntity, IComparable previousEntity)
        {
            return CompareValues(activeEntity?.Name, previousEntity?.Name) &&
                   CompareValues(activeEntity?.Description, previousEntity?.Description) &&
                   CompareValues(activeEntity?.Level, previousEntity?.Level) &&
                   CompareValues(activeEntity?.Result, previousEntity?.Result);
        }

        private bool CompareValues<T>(T active, T previous)
        {
            return active?.ToString() == previous?.ToString();
        }
    }
}
