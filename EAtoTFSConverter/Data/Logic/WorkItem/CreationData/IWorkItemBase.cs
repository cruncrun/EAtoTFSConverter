namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    interface IWorkItemBase
    {
        int Id { get; set; }
        string Name { get; set; }
        string AreaPath { get; set; }
        string Iteration { get; set; }
        string Owner { get; set; }
    }
}
