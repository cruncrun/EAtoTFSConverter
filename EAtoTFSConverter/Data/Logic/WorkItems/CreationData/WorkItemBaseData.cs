using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    public class WorkItemBaseData
    {
        public string Name { get; set; }
        public string AreaPath { get; set; }
        public string Iteration { get; set; }
        public string Owner { get; set; }
        public string Value { get; set; }
        public string Json { get; set; }
    }
}
