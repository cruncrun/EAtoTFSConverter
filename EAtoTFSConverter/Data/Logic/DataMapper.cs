using System;
using System.Net.Http;
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

        public static Project MapProject(Project source)
        {
            return new Project
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        internal static EAtoTFSConverter.WorkItem MapResponse(Task<string> responseBody)
        {
            // TODO: Mapowanie response na workitem
            return new EAtoTFSConverter.WorkItem
                ( 
                );
        }
    }
}
