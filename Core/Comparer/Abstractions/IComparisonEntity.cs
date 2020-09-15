using System;

namespace Core.Comparer.Abstractions
{
    public interface IComparisonEntity
    {
        Guid? Guid { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int? Level { get; set; }
        string Result { get; set; }
    }
}