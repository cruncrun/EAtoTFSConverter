using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    public interface IWorkItemBase
    {
        string Name { get; set; }
        string AreaPath { get; set; }
        string Iteration { get; set; }
        string Owner { get; set; }
        string Value { get; set; }
        string ApiAddress { get; set; }
        HttpContent Content { get; set; }
        int WorkItemId { get; set; }
    }
}
