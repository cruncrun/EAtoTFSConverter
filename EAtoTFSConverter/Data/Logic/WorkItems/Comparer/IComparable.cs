namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public interface IComparable
    {
        string Name { get; set; }
        string Description { get; set; }
        int? Level { get; set; }
        string Result { get; set; }
    }
}
