using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    internal class WorkItemCreationData : IWorkItemBase
    {
        public IWorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public Project Project { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get; set; }
    }
}