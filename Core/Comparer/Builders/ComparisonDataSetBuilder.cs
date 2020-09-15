using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer.Builders
{
    public class ComparisonDataSetBuilder : IComparisonDataSetBuilder
    {
        private readonly IComparisonDataSet _comparisonDataSet;

        public ComparisonDataSetBuilder()
        {
            _comparisonDataSet = new ComparisonDataSet();
        }

        public IComparisonDataSetBuilder SetGuid(Guid guid)
        {
            _comparisonDataSet.Guid = guid;
            return this;
        }

        public IComparisonDataSetBuilder SetWorkItemType(WorkItemType workItemType)
        {
            _comparisonDataSet.WorkItemType = workItemType;
            return this;
        }

        public IComparisonDataSetBuilder SetActiveEntity(IComparisonEntity entity)
        {
            _comparisonDataSet.ActiveEntity = entity;
            return this;
        }

        public IComparisonDataSetBuilder SetPreviousEntity(IComparisonEntity entity)
        {
            _comparisonDataSet.PreviousEntity = entity;
            return this;
        }

        public IComparisonDataSet Build() => _comparisonDataSet;
    }
}
