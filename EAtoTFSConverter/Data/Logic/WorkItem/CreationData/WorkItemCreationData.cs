using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    class WorkItemCreationData : IWorkItemBase
    {
        public string Name { get; set; }
        public string AreaPath { get; set; }
        public string Iteration { get; set; }
        public string Owner { get; set; }
        public string Value { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public HttpContent content { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
