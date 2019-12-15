using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparisionStep : ComparisionEntity
    {
        public Guid? Guid { get; set; }
        public Guid? EAScenarioId { get; set; }
    }
}
