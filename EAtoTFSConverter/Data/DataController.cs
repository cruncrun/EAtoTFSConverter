using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAtoTFSConverter.Data.DBOperations;
using EAtoTFSConverter.Data.XMLParse;

namespace EAtoTFSConverter.Data
{
    public class DataController
    {
        public List<EAScenario> Scenarios { get; set; } = new List<EAScenario>();
        public List<UseCase> UseCases { get; set; } = new List<UseCase>();
        public List<Step> Steps { get; set; } = new List<Step>();

        public void PrepareData(IEnumerable<XMLParse.EAScenario> result)
        {
            DateTime currentDate = DateTime.Now;

            foreach (XMLParse.EAScenario scenario in result)
            {
                scenario.Timestamp = currentDate;
                Scenarios.Add(DataMapper.MapEAScenario(scenario));

                foreach (XMLParse.UseCase useCase in scenario.UseCase)
                {
                    useCase.Timestamp = currentDate;
                    UseCases.Add(DataMapper.MapUseCase(useCase));
                }
                foreach (XMLParse.Step step in scenario.Steps)
                {
                    step.Timestamp = currentDate;
                    Steps.Add(DataMapper.MapStep(step));
                }
            }            
            InsertData();
        }

        private void InsertData()
        {
            bool operation = false;

            if (Scenarios.Any())
            {
                Insert(Scenarios);
                operation = true;
            }
            if (UseCases.Any())
            {
                Insert(UseCases);
                operation = true;
            }
            if (Steps.Any())
            {
                Insert(Steps);
                operation = true;
            }

            if (operation == true)
            {
                MessageBox.Show(
                   "Import danych z Enterprise Architect przebiegł pomyślnie!", "OK!",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Insert(List<EAScenario> scenarios)
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

        private void Insert(List<UseCase> useCases)
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

        private void Insert(List<Step> steps)
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
