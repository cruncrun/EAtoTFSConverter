using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;
using EAtoTFSConverter.Data.Logic.WorkItem.ReceivedData;


namespace EAtoTFSConverter.Data.Logic.WorkItem
{
    class WorkItemComparer
    {
        public IComparable LocalDataSet { get; set; }
        public IComparable SourceDataSet { get; set; }
        public bool ComparsionResult { get; set; }

        public WorkItemComparer(IComparable localData, IComparable sourceData)
        {
            LocalDataSet = localData;
            SourceDataSet = sourceData;
            ComparsionResult = Compare(LocalDataSet, SourceDataSet);
        }

        public WorkItemComparer()
        {
            LocalDataSet = localData;
            SourceDataSet = sourceData;
            ComparsionResult = Compare(LocalDataSet, SourceDataSet);
        }

        private bool Compare(IComparable localDataSet, IComparable sourceDataSet)
        {
            return true;
        }

        private bool CompareValues<T>(T local, T source)
        {
            return false;
        }
    }
}
