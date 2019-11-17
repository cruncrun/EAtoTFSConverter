using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem.ReceivedData;
using Microsoft.TeamFoundation.Common.Internal;

namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    interface IComparable : IReceiveable
    {
        Project Project { get; set; }
        Guid Guid { get; set; }
    }
}
