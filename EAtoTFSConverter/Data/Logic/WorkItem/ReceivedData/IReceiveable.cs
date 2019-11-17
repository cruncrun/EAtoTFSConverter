using System;

namespace EAtoTFSConverter.Data.Logic.WorkItem.ReceivedData
{
    interface IReceiveable
    {
        int WorkItemId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
