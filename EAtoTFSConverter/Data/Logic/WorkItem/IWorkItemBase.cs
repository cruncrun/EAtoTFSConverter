using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    interface IWorkItemBase
    {
        int Id { get; set; }
        string Name { get; set; }
        string AreaPath { get; set; }
        string Iteration { get; set; }
        string Owner { get; set; }
    }
}
