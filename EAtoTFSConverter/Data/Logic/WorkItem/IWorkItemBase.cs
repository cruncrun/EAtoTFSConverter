﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    interface IWorkItemBase
    {
        //bool Exists { get; set; }
        int WorkItemId { get; set; }
        //bool CheckIfExists(Project project);
    }
}
