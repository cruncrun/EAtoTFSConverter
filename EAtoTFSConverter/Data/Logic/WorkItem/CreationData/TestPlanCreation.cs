using System.Net.Http;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal class TestPlanCreation : ICreatable
    {
        public Project Project { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public OperationType OperationType { get; set; }
        public IWorkItemBase CreationData { get; set; }


        public TestPlanCreation(Project project)
        {
            Project = project;
            WorkItemType = WorkItemType.TestPlan;
        }

        public async void Prepare()
        {
            OperationType = GetOperationType();
            if (OperationType == OperationType.UseExisting)
            {
                var db = new DatabaseOperations();
                CreationData.WorkItemId = db.GetWorkItemId(Project.Id, WorkItemType);
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
            WorkItemComparer workItemComparer = new WorkItemComparer();

            return workItemComparer.ComparsionResult;
        }

        public async Task Send()
        {
            APICommunication api = new APICommunication(Project);
            await api.Send(CreationData);
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
