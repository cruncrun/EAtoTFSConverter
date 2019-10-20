﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.XMLParse
{
    public class Step
    {
        public Guid Guid { get; set; }
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}