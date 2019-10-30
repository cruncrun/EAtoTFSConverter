using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;
using EAtoTFSConverter.Data.Logic;

namespace EAtoTFSConverter.Data
{
    public class APICommunication
    {
        internal void Send(string json, Project project)
        {
            using (var connection = GetConnection(project))
            {
                IEnumerable<TeamProjectReference> projects = connection.GetProjects().Result;
            }
        }

        private ProjectHttpClient GetConnection(Project project)
        {
            Uri adres = new Uri("https://dev.azure.com/crunchips");
            string user = "user";
            string token = "r76p6njjugy6he4kzaqsiaqjyhenmoola6pxfm7fpe5t6m5c32bq";

            VssClientCredentials clientCredentials = new VssClientCredentials(
                new VssBasicCredential("", token));
            return new ProjectHttpClient(adres, clientCredentials);
        }

        //private string GetPersonalToken(Project project)
        //{

        //    DatabaseOperations db = new DatabaseOperations();
        //}
    }
}
