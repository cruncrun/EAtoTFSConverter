using System;
using Newtonsoft.Json;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestPlanCreation : IWorkItemBase
    {
        public WorkItemBaseData WorkItemBaseData { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public Guid Guid { get; set; }
        public HttpContent Content { get; set; }

        public TestPlanCreation()
        {
            WorkItemBaseData.Name = "Plan Testów";
            WorkItemBaseData.AreaPath = "EA-TFS Conversion";
            WorkItemBaseData.Iteration = "EA-TFS Conversion";
            WorkItemBaseData.Owner = null;
        }

        public TestPlanCreation(int existingItemId)
        {
            WorkItemId = existingItemId;
        }
    }
}
