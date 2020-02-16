using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAtoTFSConverter.Data.Logic;

namespace EAtoTFSConverter.Data
{
    internal class ParsedDataController
    {
        public ParsedDataController(Project project)
        {
            Project = project;
        }

        private List<EAScenario> Scenarios { get; } = new List<EAScenario>();
        private List<UseCase> UseCases { get; } = new List<UseCase>();
        private List<Step> Steps { get; } = new List<Step>();
        public Project Project { get; set; }

        public void PrepareData(IEnumerable<XMLParse.EAScenario> result)
        {
            var currentDate = DateTime.Now;

            try
            {
                foreach (var scenario in result)
                {
                    var db = new DatabaseOperations();

                    scenario.Timestamp = currentDate;
                    scenario.PreviousVersionId = db.GetActive_EAscenarios(Project)
                        .Where(s => s.ProjectId == scenario.ProjectId && s.XmiId == scenario.XmiId)
                        .Select(s => s.Id)
                        .FirstOrDefault();

                    Scenarios.Add(DataMapper.MapEAScenario(scenario));

                    foreach (var useCase in scenario.UseCase)
                    {
                        useCase.Id = Guid.NewGuid();
                        useCase.Timestamp = currentDate;
                        useCase.EAScenarioId = scenario.Id;
                        UseCases.Add(useCase);
                    }

                    foreach (var step in scenario.Steps)
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
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        private void InsertEAData()
        {
            var operationSuccess = true;

            try
            {
                var db = new DatabaseOperations();
                if (Scenarios.Any()) operationSuccess &= db.Insert(Scenarios);
                if (UseCases.Any()) operationSuccess &= db.Insert(UseCases);
                if (Steps.Any()) operationSuccess &= db.Insert(Steps);
                if (operationSuccess)
                    MessageBox.Show(
                        "Import danych z Enterprise Architect przebiegł pomyślnie!", "OK!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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