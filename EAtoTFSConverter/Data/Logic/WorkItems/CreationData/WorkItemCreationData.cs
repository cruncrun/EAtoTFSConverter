using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    internal class WorkItemCreationData : IWorkItemBase
    {
        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get; set; }

        public WorkItemCreationData()
        {
            WorkItemBaseData = new WorkItemBaseData();
        }
    }
}
