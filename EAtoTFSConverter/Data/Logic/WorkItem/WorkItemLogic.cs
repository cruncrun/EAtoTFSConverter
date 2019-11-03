using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data.Logic
{
    class WorkItemLogic
    {
        public Project Project { get; set; }

        public WorkItemLogic(Project selectedProject)
        {
            Project = selectedProject;
        }

        internal void PrepareData()
        {
            WorkItemDataSet workItemDataSet = new WorkItemDataSet();
            workItemDataSet.TestPlan = PrepareTestPlanData();            
        }

        private TestPlan PrepareTestPlanData()
        {       
            bool exists = CheckIfExists();
            return exists ? GetTestPlanData() : CreateNewTestPlan();            
        }

        private TestPlan CreateNewTestPlan()
        {
            // 1.  Przygotowanie komunikatu do API
            var json = JsonConvert.SerializeObject(new TestPlanCreationData(), Formatting.Indented);

            // 2.  Wysyłka komnunikatu
            // 3.  Odebranie odpowiedzi
            APICommunication api = new APICommunication(Project);
            api.Send(json, Project);

            

            // 4.  Zapis danych z odpowiedzi do bazy

            // 5.  Przygotowanie i zwrot obiektu.






            return new TestPlan();
        }

        internal bool CheckIfExists()
        {
            int result;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                result = dataContext.TestPlans
                    .Where(tp => tp.ProjectId == Project.Id)
                    .Count();
            }
            if (result > 1)
            {
                MessageBox.Show(
                    "Wybrany projekt ma zdefiniowany więcej niż jeden Test Plan, zgłoś się do prokuratora psa.", "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return result == 1;
        }

        internal TestPlan GetTestPlanData()
        {
            TestPlan testPlan = new TestPlan();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                testPlan = dataContext.TestPlans
                    .Where(tp => tp.ProjectId == Project.Id)
                    .FirstOrDefault();
            }
            return testPlan;
        }
    }
}
