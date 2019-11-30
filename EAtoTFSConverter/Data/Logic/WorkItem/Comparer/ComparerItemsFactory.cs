using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class ComparerItemsFactory
    {
        private ComparedDataSet dataSet = new ComparedDataSet();

        public ComparedDataSet CreateDataSet(IEnumerable<active_EAscenario> scenarios, IEnumerable<active_Step> steps)
        {
            dataSet.ComparedScenarios = PrepareScenarios(scenarios);
            dataSet.ComparedSteps = PrepareSteps(steps);
            return dataSet;
        }

        private IEnumerable<ComparsionStep> PrepareSteps(IEnumerable<active_Step> activeSteps)
        {
            var steps = new List<ComparsionStep>();
            foreach (var step in activeSteps)
            {
                steps.Add(new ComparsionStep
                {
                    Name = step.Name,
                    Description = null,
                    Level = step.Level,
                    Result = step.Result,
                    Guid = step.Id,
                    EAScenarioId = step.EAScenarioId
                });
            }
            return steps;
        }

        private IEnumerable<ComparsionScenario> PrepareScenarios(IEnumerable<active_EAscenario> activeEAscenarios)
        {
            var scenarios = new List<ComparsionScenario>();
            foreach (var scenario in activeEAscenarios)
            {
                scenarios.Add(new ComparsionScenario
                {
                    Name = scenario.Name,
                    Description = scenario.Description,
                    Level = 0,
                    Result = null,
                    Guid = scenario.Id
                });
            }
            return scenarios;
        }
    }
}
