using System.Net.Http;
using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    class TestPlanCreationData : IWorkItemBase
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("areapath")]
        public string AreaPath { get; set; }
        [JsonProperty("iteration")]
        public string Iteration { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }

        public string Value { get; set; }
        public string ApiAddress { get; set; }
        public int WorkItemId { get; set; }
        public HttpContent Content { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public TestPlanCreationData()
        {
            Name = "Plan Testów";
            AreaPath = "EA-TFS Conversion";
            Iteration = "EA-TFS Conversion";
            Owner = null;
        }

        public TestPlanCreationData(int existingItemId)
        {
            WorkItemId = existingItemId;
        }
    }
}
