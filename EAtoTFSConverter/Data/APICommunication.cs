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
using System.Net.Http;
using System.Net.Http.Headers;
using EAtoTFSConverter.Data.Logic.WorkItem;
using EAtoTFSConverter.Data.Logic.WorkItem.CreationData;

namespace EAtoTFSConverter.Data
{
    public class APICommunication
    {
        public Project Project { get; set; }
        public string AuthorizationToken { get; set; }
        public Uri BaseAddress { get; set; }

        public APICommunication(Project project)
        {
            Project = project;
            AuthorizationToken = GetPersonalToken(Project);
            BaseAddress = GetUriAddress(Project);
        }

        internal async Task Send(IWorkItemBase workItemBase)
        {
            using (var client = GetConnection())
            {                
                
            }            
        }

        private HttpClient GetConnection()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", AuthorizationToken))));
            client.BaseAddress = BaseAddress;            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "EAToTFSConverter");
            client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
            return client;
        }        

        private static string GetPersonalToken(Project project)
        {
            string authToken = null;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                authToken = dataContext.Projects
                    .Where(p => p.Id == project.Id)
                    .Select(t => t.AuthorizationToken)
                    .FirstOrDefault()?
                    .ToString();
            }
            return authToken;
        }
        private Uri GetUriAddress(Project project)
        {
            string address = null;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                address = dataContext.Projects
                    .Where(p => p.Id == project.Id)
                    .Select(t => t.Address)
                    .FirstOrDefault()?
                    .ToString();
            }
            return new Uri(address);
        }
    }
}
