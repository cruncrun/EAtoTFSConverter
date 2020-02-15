using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAtoTFSConverter.Data.Logic;
using EAtoTFSConverter.Data.Logic.WorkItems;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;

namespace EAtoTFSConverter.Data
{
    internal class ApiCommunication
    {
        public ApiCommunication(Project project)
        {
            Project = project;
            DatabaseOperations = new DatabaseOperations();
            AuthorizationToken = DatabaseOperations.GetPersonalToken(Project);
            BaseAddress = GetUriAddress();
        }

        private DatabaseOperations DatabaseOperations { get; }
        private Project Project { get; }
        private string AuthorizationToken { get; }
        private Uri BaseAddress { get; }

        internal async Task SendMessage(IWorkItemBase message)
        {
            using (var client = GetConnection(message.WorkItemType))
            {
                var response = await client.PostAsync(message.ApiAddress, message.Content);
                if (response.IsSuccessStatusCode)
                    StoreResponse(response.Content.ReadAsStringAsync().Result);
                else
                    MessageBox.Show(
                        "Wystąpił bład podczas wysyłki danych do API DevOps!\n" + 
                        response.StatusCode + "\n" +
                        response.Content.ReadAsStringAsync().Result,
                        "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void StoreResponse(string responseBody)
        {
            var db = new DatabaseOperations();
            db.Insert(DataMapper.MapResponse(responseBody));
        }

        private HttpClient GetConnection(WorkItemType workItemType)
        {
            var client = new HttpClient(new HttpClientHandler {UseDefaultCredentials = true});
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue {NoCache = true};
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{""}:{AuthorizationToken}")));
            client.BaseAddress = BaseAddress;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(workItemType == WorkItemType.TestCase
                ? "application/json-patch+json"
                : "application/json"));
            return client;
        }

        private Uri GetUriAddress()
        {
            return new Uri(DatabaseOperations.GetUriAddress(Project));
        }
    }
}