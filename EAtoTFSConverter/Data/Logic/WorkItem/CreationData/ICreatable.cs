using System.Threading.Tasks;
using IComparable = EAtoTFSConverter.Data.Logic.WorkItem.Comparer.IComparable;

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
