using System.Net.Http;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem.Comparer;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal class WorkItemCreationLogic : ICreatable
    {
        public Project Project { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public OperationType OperationType { get; set; }
        public IWorkItemBase CreationData { get; set; }
        
        public WorkItemCreationLogic(Project project, WorkItemType workItemType)
        {
            Project = project;
            WorkItemType = workItemType;
        }

        public async void Prepare()
        {
            OperationType = GetOperationType();
            if (OperationType == OperationType.UseExisting)
            {
                var db = new DatabaseOperations();
                CreationData.WorkItemId = db.GetWorkItem(Project.Id, WorkItemType);
            }

            else 
            {
                await Send();
            }
        }

        public bool CheckIfExists()
        {
            var db = new DatabaseOperations();
            return db.CheckWorkItem(Project.Id, WorkItemType);
        }

        public bool Compare()
        {
            //WorkItemComparer workItemComparer = new WorkItemComparer();

            //return workItemComparer.ComparsionResult;

            return true;
        }

        public async Task Send()
        {
            var api = new APICommunication(Project);
            var message = MessageFactory.BuildMessage(WorkItemType, OperationType, CreationData);
            await api.Send(message);
        }
        public OperationType GetOperationType() =>
            CheckIfExists()
                ? (Compare()
                    ? OperationType.UseExisting
                    : OperationType.Update)
                : OperationType.CreateNew;

        public string CreateMessage(OperationType operationType)
        {
            string result = "";
            if (operationType == OperationType.CreateNew)
            {
                // new CreationData
                // result = nowy komunikat
            }

            if (operationType == OperationType.Update)
            {
                // CreationData z wykorzystaniem istniejących danych
                // result = update
            }
            // Stworzenie jsona z CreationData

            return result;
        }

        public IComparable GetLocalData()
        {
            // do wykorzystania w CheckIfExists
            throw new System.NotImplementedException();
        }
    }
}
