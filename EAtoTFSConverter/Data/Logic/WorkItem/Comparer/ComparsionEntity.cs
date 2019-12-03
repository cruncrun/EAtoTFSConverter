using System;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    public class ComparsionEntity : IComparable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
        public string Result { get; set; }
    }
}
