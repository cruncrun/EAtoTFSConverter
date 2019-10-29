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
        internal List<active_EAscenario> GetActive_EAscenarios(Project selectedProject)
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

        internal IEnumerable<active_Step> GetActive_Steps(active_EAscenario eaScenario)
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

        internal List<active_Step> GetActive_Steps()
        {
            List<active_Step> active_Steps = new List<active_Step>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                active_Steps = dataContext.active_Steps
                    .ToList();
            }
            return active_Steps;
        }

        internal bool Insert(List<EAScenario> scenarios)
        {
            bool result;
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.EAScenarios.InsertAllOnSubmit(scenarios);
                    dataContext.SubmitChanges();
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }             
            return result;            
        }

        internal bool Insert(List<UseCase> useCases)
        {
            bool result;
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.UseCases.InsertAllOnSubmit(useCases);
                    dataContext.SubmitChanges();
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            return result;
        }

        internal bool Insert(List<Step> steps)
        {
            bool result;
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    dataContext.Steps.InsertAllOnSubmit(steps);
                    dataContext.SubmitChanges();
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            return result;
        }
    }
}
