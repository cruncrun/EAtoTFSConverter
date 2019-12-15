using System;

namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    public class ComparsionStep : ComparsionEntity
    {
        public Guid? Guid { get; set; }
        public Guid? EAScenarioId { get; set; }
    }
}
