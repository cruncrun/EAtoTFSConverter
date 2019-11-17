using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal interface ICreatable
    {
        bool Exists { get; set; }
        IWorkItemBase CreationData { get; set; }
        Task Prepare();
        bool CheckIfExists();
        bool Compare();
        string CreateMessage();
        IComparable GetLocalData();
    }
}
