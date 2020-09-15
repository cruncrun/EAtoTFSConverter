using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer
{
    public class ComparisonDataSet : IComparisonDataSet
    {
        public IComparisonEntity ActiveEntity { get; set; }
        public IComparisonEntity PreviousEntity { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }
    }
}