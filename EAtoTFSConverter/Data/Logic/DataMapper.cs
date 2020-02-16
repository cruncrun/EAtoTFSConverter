using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
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

        internal static WorkItem MapResponse(IWorkItemBase message, string responseBody)
        {
            var definition = new { Id = "", Title = "", Description = "", Value = "" };
            var deserializedResponse = JsonConvert.DeserializeAnonymousType(responseBody, definition);

            try
            {
                return new WorkItem()
                {
                    Id = Guid.NewGuid(),
                    EAId = message.Guid,
                    ProjectId = message.Project.Id,
                    WorkItemId = Convert.ToInt32(deserializedResponse.Id),
                    WorkItemType = (short)message.WorkItemType,
                    Name = deserializedResponse.Title,
                    Description = deserializedResponse.Description,
                    Value = null
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
    }
}