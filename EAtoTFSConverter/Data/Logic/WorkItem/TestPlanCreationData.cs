using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
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

        public TestPlanCreationData()
        {
            Name = "Plan Testów";
            AreaPath = "EA-TFS Conversion";
            Iteration = "EA-TFS Conversion";
            Owner = null;
        }
    }
}
