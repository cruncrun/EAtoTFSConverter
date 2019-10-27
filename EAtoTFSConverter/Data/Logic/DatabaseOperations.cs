using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data.Logic
{
    public class DatabaseOperations
    {
        public List<active_EAscenario> GetActive_EAscenarios(Project selectedProject)
        {
            List<active_EAscenario> active_EAscenarios = new List<active_EAscenario>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                active_EAscenarios = dataContext.active_EAscenarios
                    .Where(s => s.ProjectId == selectedProject.Id)
                    .ToList();
            }
            return active_EAscenarios;
        }

        public List<active_Step> GetActive_Steps(active_EAscenario eaScenario)
        {
            List<active_Step> active_Steps = new List<active_Step>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                active_Steps = dataContext.active_Steps
                    .Where(s => s.EAScenarioId == eaScenario.Id)
                    .ToList();
            }
            return active_Steps;
        }

        public List<active_Step> GetActive_Steps()
        {
            List<active_Step> active_Steps = new List<active_Step>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                active_Steps = dataContext.active_Steps
                    .ToList();
            }
            return active_Steps;
        }

        public void Insert(List<EAScenario> scenarios)
        {
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.EAScenarios.InsertAllOnSubmit(scenarios);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

        }

        public void Insert(List<UseCase> useCases)
        {
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.UseCases.InsertAllOnSubmit(useCases);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

        }

        public void Insert(List<Step> steps)
        {
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.Steps.InsertAllOnSubmit(steps);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

        }
    }
}
