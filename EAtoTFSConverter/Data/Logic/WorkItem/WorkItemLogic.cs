﻿using Newtonsoft.Json;
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
        internal void PrepareData(Project project)
        {
            WorkItemDataSet workItemDataSet = new WorkItemDataSet();
            workItemDataSet.TestPlan = PrepareTestPlanData(project);
        }

        private TestPlan PrepareTestPlanData(Project project)
        {       
            bool exists = CheckIfExists(project);
            return exists ? GetTestPlanData(project) : CreateNewTestPlan(project);            
        }

        private TestPlan CreateNewTestPlan(Project project)
        {
            var json = JsonConvert.SerializeObject(project, Formatting.Indented);
            /*  1.  Przygotowanie komunikatu do API
             *  2.  Wysyłka komnunikatu
             *  3.  Odebranie odpowiedzi
             *  4.  Zapis danych z odpowiedzi do bazy
             *  5.  Przygotowanie i zwrot obiektu.
             */

            APICommunication api = new APICommunication();
            api.Send(json, project);
            //await Send(json);

            return new TestPlan();
        }

        //private static async Task Send(string json)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var content = new FormUrlEncodedContent(json);
        //        var resposne = await client.PostAsync("https://dev.azure.com/{organization}/{project}/_apis/testplan/plans?api-version=5.1-preview.1", content);
        //        var responseString = await response.Content.ReadAsStringAsync();
        //    }
        //}

        internal bool CheckIfExists(Project project)
        {
            int result;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                result = dataContext.TestPlans
                    .Where(tp => tp.ProjectId == project.Id)
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

        internal TestPlan GetTestPlanData(Project project)
        {
            TestPlan testPlan = new TestPlan();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                testPlan = dataContext.TestPlans
                    .Where(tp => tp.ProjectId == project.Id)
                    .FirstOrDefault();
            }
            return testPlan;
        }
    }
}