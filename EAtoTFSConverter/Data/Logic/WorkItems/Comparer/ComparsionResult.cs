namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparsionResult
    {
        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }

        public ComparsionResult(WorkItemType workItemType)
        {
            WorkItemType = workItemType;
        }

        public ComparsionResult()
        {

        }
    }
}
