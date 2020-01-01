using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestCaseCreation : IWorkItemBase
    {
        public TestCaseCreation(Guid id)
        {
            throw new NotImplementedException();
        }

        public TestCaseCreation()
        {
            
        }

        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get; set; }
    }
}
