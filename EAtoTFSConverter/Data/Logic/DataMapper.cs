using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EAtoTFSConverter.Data.Logic
{
    internal static class DataMapper
    {
        public static EAScenario MapEAScenario(XMLParse.EAScenario source)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        public static Project MapProject(Project source)
        {
            try
            {
                return new Project
                {
                    Id = source.Id,
                    Name = source.Name
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        internal static WorkItem MapResponse(string responseBody)
        {
            try
            {
                // TODO: Mapowanie response na workitem
                return JsonConvert.DeserializeObject<WorkItem>(responseBody.ToString());
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