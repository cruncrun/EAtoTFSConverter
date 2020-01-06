namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class ComparisionEntity : IComparable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
        public string Result { get; set; }
    }
}
