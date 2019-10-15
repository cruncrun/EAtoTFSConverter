using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.XMLParse
{
    public class UseCase
    {
        public Guid Guid { get; set; }
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
