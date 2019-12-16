using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestSuiteCreationData : IWorkItemBase
    {
        public string Name { get; set; }
        public string AreaPath { get; set; }
        public string Iteration { get; set; }
        public string Owner { get; set; }
        public string Value { get; set; }
        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
