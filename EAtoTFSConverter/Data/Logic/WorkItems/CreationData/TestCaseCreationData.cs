using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestCaseCreationData : IWorkItemBase
    {
        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public HttpContent Content { get; set; }
    }
}
