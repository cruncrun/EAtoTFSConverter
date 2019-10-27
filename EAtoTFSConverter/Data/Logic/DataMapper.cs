using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    static class DataMapper
    {   
        public static EAScenario MapEAScenario(XMLParse.EAScenario source)
        {
            return new EAScenario
            {
                Id = source.Id,
                SubjectId = source.SubjectId,
                ProjectId = source.ProjectId,
                Name = source.Name,
                Type = source.Type,
                Description = source.Description,
                XmiId = source.XmiId,
                Timestamp = source.Timestamp
            }; 
        }

        public static UseCase MapUseCase(UseCase source)
        {
            return new UseCase
            {
                Id = Guid.NewGuid(),
                EAScenarioId = source.EAScenarioId,
                Guid = source.Guid,
                SubjectId = source.SubjectId,
                Name = source.Name,
                Timestamp = source.Timestamp
            };
        }

        public static Step MapStep(Step source)
        {
            return new Step
            {
                Id = Guid.NewGuid(),
                Guid = source.Guid,
                EAScenarioId = source.EAScenarioId,
                SubjectId = source.SubjectId,
                Name = source.Name,
                Level = source.Level,
                Result = source.Result,
                Timestamp = source.Timestamp
            };
        }

        public static Project MapProject(Project source)
        {
            return new Project
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
