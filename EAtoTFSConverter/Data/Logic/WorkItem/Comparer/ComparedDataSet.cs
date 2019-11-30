using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class ComparedDataSet
    {
        public IEnumerable<ComparsionScenario> ComparedScenarios { get; set; }
        public IEnumerable<ComparsionStep> ComparedSteps { get; set; }

    }
}
