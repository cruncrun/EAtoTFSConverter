namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparisionResult
    {
        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }

        public ComparisionResult(WorkItemType workItemType)
        {
            WorkItemType = workItemType;
        }

        public ComparisionResult()
        {

        }
    }
}
