using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer
{
    internal class ComparisonScenario : IComparisonEntity
    {
        public Guid? Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
        public string Result { get; set; }
    }
}