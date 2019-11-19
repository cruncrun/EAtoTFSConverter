using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.ReceivedData
{
    class TestPlanReceivedData : IReceiveable
    {
        public int WorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
