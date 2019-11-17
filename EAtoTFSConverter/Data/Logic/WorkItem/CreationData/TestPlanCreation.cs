using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.CreationData
{
    internal class TestPlanCreation : ICreatable
    {
        public Project Project { get; set; }
        public bool Exists { get; set; }
        public IWorkItemBase CreationData { get; set; }


        public TestPlanCreation(Project project)
        {
            Project = project;
        }

        public async Task Prepare()
        {
            if (!Exists == CheckIfExists())
            {
                APICommunication api = new APICommunication(Project);
                await api.Send(CreateMessage());
            }
        }

        public bool CheckIfExists()
        {
            // wyszukanie w bazie WorkItem rekordu dla danego projectId i WorkItemType = 0
            // jeżeli zostanie znaleziony: ustawienie Exists = true i wstawienie WorkItemId do CreationData
            // jeżeli nie: ustawienie Exists = false i stworzenie nowego obiektu CreationData
            throw new System.NotImplementedException();
        }

        public bool Compare()
        {
            throw new System.NotImplementedException();
        }

        public string CreateMessage()
        {
            // Stworzenie jsona z CreationData
            throw new System.NotImplementedException();
        }

        public IComparable GetLocalData()
        {
            // do wykorzystania w CheckIfExists
            throw new System.NotImplementedException();
        }
    }
}
