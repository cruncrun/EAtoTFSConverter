using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class ComparisionStep : ComparisionEntity
    {
        public Guid? Guid { get; set; }
        public Guid? EAScenarioId { get; set; }
    }
}