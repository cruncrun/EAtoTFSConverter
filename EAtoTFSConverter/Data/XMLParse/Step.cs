using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.XMLParse
{
    class Step
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Result { get; set; }
    }
}
