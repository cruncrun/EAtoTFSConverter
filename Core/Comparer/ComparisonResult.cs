using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer
{
    internal class ComparisonResult : IComparisonResult
    {
        public bool Result { get; set; }
        public OperationType OperationType { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public Guid Guid { get; set; }
        public Project Project { get; set; }
    }
}