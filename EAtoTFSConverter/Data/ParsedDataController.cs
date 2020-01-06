using EAtoTFSConverter.Data.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data
{
    internal class ParsedDataController
    {
        private List<EAScenario> Scenarios { get; set; } = new List<EAScenario>();
        private List<UseCase> UseCases { get; set; } = new List<UseCase>();
        private List<Step> Steps { get; set; } = new List<Step>();
        public Project Project { get; set; }

        public ParsedDataController(Project project)
        {
            Project = project;
        }

        public void PrepareData(IEnumerable<XMLParse.EAScenario> result)
        {
            DateTime currentDate = DateTime.Now;

            foreach (XMLParse.EAScenario scenario in result)
            {
                DatabaseOperations db = new DatabaseOperations();

                scenario.Timestamp = currentDate;
                scenario.PreviousVersionId = db.GetActive_EAscenarios(Project)
                    .Where(s => s.ProjectId == scenario.ProjectId && s.XmiId == scenario.XmiId)
                    .Select(s => s.Id)
                    .FirstOrDefault();

                Scenarios.Add(DataMapper.MapEAScenario(scenario));

                foreach (UseCase useCase in scenario.UseCase)
                {
                    useCase.Id = Guid.NewGuid();
                    useCase.Timestamp = currentDate;
                    useCase.EAScenarioId = scenario.Id;
                    UseCases.Add(useCase);
                }
                foreach (Step step in scenario.Steps)
                {
                    step.Id = Guid.NewGuid();
                    step.Timestamp = currentDate;
                    step.EAScenarioId = scenario.Id;
                    step.PreviousVersionId = db.GetActive_Steps()
                        .Where(s => s.EAScenarioId == scenario.Id && s.Guid == step.Id)
                        .Select(s => s.Id)
                        .FirstOrDefault();
                    Steps.Add(step);
                }
            }
            InsertEAData();
        }

        private void InsertEAData()
        {
            bool operationSuccess = true;

            DatabaseOperations db = new DatabaseOperations();
            if (Scenarios.Any())
            {
                operationSuccess &= db.Insert(Scenarios);
            }
            if (UseCases.Any())
            {                
                operationSuccess &= db.Insert(UseCases);
            }
            if (Steps.Any())
            {
                operationSuccess &= db.Insert(Steps);
            }
            if (operationSuccess)
            {
                MessageBox.Show(
                   "Import danych z Enterprise Architect przebiegł pomyślnie!", "OK!",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
