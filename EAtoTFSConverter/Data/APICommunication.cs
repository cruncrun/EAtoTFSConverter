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

namespace EAtoTFSConverter.Data
{
    public class APICommunication
    {
        internal const string authorizationToken = "r76p6njjugy6he4kzaqsiaqjyhenmoola6pxfm7fpe5t6m5c32bq";
        private static readonly Uri address = new Uri("https://dev.azure.com/crunchips/EA-TFS%20Conversion/");

        internal async Task Send(string json, Project project)
        {
            using (var client = GetConnection())
            {                
                //HttpResponseMessage response = await client.GetAsync(address + $"_apis/testplan/plans?api-version=5.1-preview.1");
                HttpResponseMessage response = await client.PostAsJsonAsync(address + $"_apis/testplan/plans?api-version=5.1-preview.1", json);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }            
        }

        private HttpClient GetConnection()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", authorizationToken))));
            client.BaseAddress = address;            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "EAToTFSConverter");
            client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
            return client;
        }        

        private string GetPersonalToken(Project project)
        {
            DatabaseOperations db = new DatabaseOperations();
            return "token";
        }
    }
}
