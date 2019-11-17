using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class ComparsionDataSet : IComparable
    {
        public int WorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }
    }
}
