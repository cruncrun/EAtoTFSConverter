using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal interface ICreatable
    {
        Project Project { get; set; }
        WorkItemType WorkItemType { get; set; }
        OperationType OperationType { get; set; }
        IWorkItemBase CreationData { get; set; }
        void Prepare();
        bool CheckIfExists();
        bool Compare();
        Task Send();
        OperationType GetOperationType();
        string CreateMessage(OperationType operationType);
        IComparable GetLocalData();
    }
}
