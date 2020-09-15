using System;
using Core.Comparer.Abstractions;

namespace Core.Comparer.Builders
{
    class ComparisonResultBuilder : IComparisonResultBuilder
    {
        private readonly IComparisonResult _comparisonResult;

        public ComparisonResultBuilder()
        {
            _comparisonResult = new ComparisonResult();
        }

        public IComparisonResultBuilder SetGuid(Guid guid)
        {
            _comparisonResult.Guid = guid;
            return this;
        }

        public IComparisonResultBuilder SetOperationType(OperationType operationType)
        {
            _comparisonResult.OperationType = operationType;
            return this;
        }

        public IComparisonResultBuilder SetWorkItemType(WorkItemType workItemType)
        {
            _comparisonResult.WorkItemType = workItemType;
            return this;
        }

        public IComparisonResultBuilder SetProject(Project project)
        {
            _comparisonResult.Project = project;
            return this;
        }

        public IComparisonResult Build() => _comparisonResult;
    }
}
