using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.DBOperations
{
    static class DataMapper
    {
        public static void CheckIfExists(Guid subjectId)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {

            }            
        }

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

        public static UseCase MapUseCase(XMLParse.UseCase source)
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

        public static Step MapStep(XMLParse.Step source)
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

        public static Project MapProject(EAtoTFSConverter.Project source)
        {
            return new Project
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
