using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.XMLParse
{
    class EAScenario
    {
        public string Name { get; set; }
        public string Xmi_Id { get; set; }
        public string Type { get; set; }
        public IEnumerable<UseCase> UseCase { get; set; }
        public IEnumerable<Step> Steps { get; set; }
    }
}
