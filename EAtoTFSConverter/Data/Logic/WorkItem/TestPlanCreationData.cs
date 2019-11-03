using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    class TestPlanCreationData : IWorkItemBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AreaPath { get; set; }
        public string Iteration { get; set; }
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
