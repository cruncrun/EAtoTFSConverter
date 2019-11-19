namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    public interface IWorkItemBase
    {
        string Name { get; set; }
        string AreaPath { get; set; }
        string Iteration { get; set; }
        string Owner { get; set; }
        string Value { get; set; }
        string ApiAddress { get; set; }
        int WorkItemId { get; set; }
}
}
