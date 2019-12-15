using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem;
using IComparable = EAtoTFSConverter.Data.Logic.WorkItems.Comparer.IComparable;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
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
