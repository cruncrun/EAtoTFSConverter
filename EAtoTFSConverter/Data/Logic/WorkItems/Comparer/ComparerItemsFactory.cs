namespace EAtoTFSConverter.Data.Logic.WorkItems.Comparer
{
    internal class ComparerItemsFactory
    {
        internal ComparisionStep MapToComparsionEntity(active_Step source)
        {
            return new ComparisionStep
            {
                Name = source.Name,
                Description = null,
                Level = source.Level,
                Result = source.Result,
                Guid = source.Id,
                EAScenarioId = source.EAScenarioId
            };
        }

        internal ComparisionScenario MapToComparsionEntity(active_EAscenario source)
        {
            return new ComparisionScenario
            {
                Name = source.Name,
                Description = source.Description,
                Level = null,
                Result = null,
                Guid = source.Id
            };
        }

        internal ComparisionScenario MapToComparsionEntity(EAScenario source)
        {
            return new ComparisionScenario()
            {
                Name = source?.Name,
                Description = source?.Description,
                Level = null,
                Result = null,
                Guid = source?.Id
            };
        }

        internal ComparisionStep MapToComparsionEntity(Step source)
        {
            return new ComparisionStep()
            {
                Name = source?.Name,
                Level = source?.Level,
                Result = source?.Result,
                Guid = source?.Id,
                EAScenarioId = source?.EAScenarioId,
                Description = null
            };
        }


    }
}
