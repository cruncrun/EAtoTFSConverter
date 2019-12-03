namespace EAtoTFSConverter.Data.Logic.WorkItem.Comparer
{
    class ComparerItemsFactory
    {
        internal ComparsionStep MapToComparsionEntity(active_Step source)
        {
            return new ComparsionStep
            {
                Name = source.Name,
                Description = null,
                Level = source.Level,
                Result = source.Result,
                Guid = source.Id,
                EAScenarioId = source.EAScenarioId
            };
        }

        internal ComparsionScenario MapToComparsionEntity(active_EAscenario source)
        {
            return new ComparsionScenario
            {
                Name = source.Name,
                Description = source.Description,
                Level = null,
                Result = null,
                Guid = source.Id
            };
        }

        internal ComparsionScenario MapToComparsionEntity(EAScenario source)
        {
            return new ComparsionScenario()
            {
                Name = source?.Name,
                Description = source?.Description,
                Level = null,
                Result = null,
                Guid = source?.Id
            };
        }

        internal ComparsionStep MapToComparsionEntity(Step source)
        {
            return new ComparsionStep()
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
