using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class ComparsionStep : ComparsionEntity
    {
        public Guid? Guid { get; set; }
        public Guid? EAScenarioId { get; set; }
    }
}
