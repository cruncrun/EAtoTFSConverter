using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    public interface IWorkItemBaseData
    {
    }

    internal class WorkItemBaseDataTestPlan : IWorkItemBaseData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    internal class WorkItemBaseDataTestCase : IWorkItemBaseData
    {
        [JsonProperty("op")]
        public string Op { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    internal class WorkItemBaseDataTestSuite : IWorkItemBaseData
    {

    }
}