using System;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    public class ComparsionStep : ComparsionEntity
    {
        public Guid? Guid { get; set; }
        public Guid? EAScenarioId { get; set; }
    }
}
