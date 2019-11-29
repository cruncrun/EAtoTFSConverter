using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IComparable = EAtoTFSConverter.Data.Logic.WorkItem.Comparer.IComparable;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    class TestCaseCreation : ICreatable
    {
        public bool Exists { get; set; }
        public Project Project { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public OperationType OperationType { get; set; }
        public IWorkItemBase CreationData { get; set; }
        public Task Prepare()
        {
            throw new NotImplementedException();
        }

        void ICreatable.Prepare()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfExists()
        {
            throw new NotImplementedException();
        }

        public bool Compare()
        {
            throw new NotImplementedException();
        }

        public Task Send()
        {
            throw new NotImplementedException();
        }

        public OperationType GetOperationType()
        {
            throw new NotImplementedException();
        }

        public string CreateMessage(OperationType operationType)
        {
            throw new NotImplementedException();
        }

        public string CreateMessage()
        {
            throw new NotImplementedException();
        }

        public IComparable GetLocalData()
        {
            throw new NotImplementedException();
        }
    }
}
