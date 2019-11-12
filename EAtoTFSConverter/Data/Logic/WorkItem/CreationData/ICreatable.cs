using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal interface ICreatable
    {
        bool Exists { get; set; }
        string JsonToSend { get; set; }

        bool CheckIfExists();
        bool Compare();
        ICreatable GetLocalData();
    }
}
