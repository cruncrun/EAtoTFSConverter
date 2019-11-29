using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.XMLParse
{
    public class EAScenario
    {
        public Guid Id { get; set; }
        public string SubjectId { get; set; }
        public string XmiId { get; set; }
        public Guid PreviousVersionId { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }   
        public string Type { get; set; }
        public string Description { get; set; }
        public IEnumerable<UseCase> UseCase { get; set; }
        public IEnumerable<Step> Steps { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
