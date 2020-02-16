using System;
using System.Net.Http;

namespace EAtoTFSConverter.Data.Logic.WorkItems.CreationData
{
    internal interface IWorkItemBase
    {
        IWorkItemBaseData WorkItemBaseData { get; set; }
        string ApiAddress { get; set; }
        Project Project { get; set; }
        HttpContent Content { get; set; }
        WorkItemType WorkItemType { get; set; }
        int WorkItemId { get; set; }
        Guid Guid { get; set; }
    }
}