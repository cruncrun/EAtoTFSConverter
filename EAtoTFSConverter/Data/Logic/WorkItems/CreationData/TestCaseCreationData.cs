using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestCaseCreationData : IWorkItemBase
    {
        public TestCaseCreationData(Guid id)
        {
            throw new NotImplementedException();
        }

        public TestCaseCreationData()
        {
            
        }

        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get; set; }
    }
}
