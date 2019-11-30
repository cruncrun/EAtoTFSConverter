using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.Logic.WorkItem.Comparer;

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

        public static Project MapProject(Project source)
        {
            return new Project
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public static ComparsionEntity MapToComparsionEntity(EAScenario source)
        {
            return new ComparsionEntity()
            {
                Name = source.Name,
                Description = source.Description
            };
        }

        public static ComparsionEntity MapToComparsionEntity(Step source)
        {
            return new ComparsionEntity()
            {
                Name = source.Name,
                Level = source.Level,
                Result = source.Result
            };
        }
    }
}
