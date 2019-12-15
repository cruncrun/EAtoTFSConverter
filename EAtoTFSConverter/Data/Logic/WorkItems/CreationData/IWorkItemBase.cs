using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    public interface IWorkItemBase
    {
        WorkItemBaseData WorkItemBaseData { get; set; }
        string ApiAddress { get; set; }
        HttpContent Content { get; set; }
        int WorkItemId { get; set; }
    }
}
