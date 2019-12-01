namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    interface IComparable
    {
        string Name { get; set; }
        string Description { get; set; }
        int? Level { get; set; }
        string Result { get; set; }
    }
}
