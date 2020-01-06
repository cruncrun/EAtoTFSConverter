using EAtoTFSConverter.Data.Logic;
using EAtoTFSConverter.Data.Logic.WorkItems.CreationData;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data
{
    internal class APICommunication
    {
        private DatabaseOperations DatabaseOperations { get; }
        private Project Project { get; }
        private string AuthorizationToken { get; }
        private Uri BaseAddress { get; }

        public APICommunication(Project project)
        {
            Project = project;
            DatabaseOperations = new DatabaseOperations();
            AuthorizationToken = DatabaseOperations.GetPersonalToken(Project);
            BaseAddress = GetUriAddress();

        }

        internal async Task SendMessage(IWorkItemBase message)
        {
            using (var client = GetConnection())
            {
                var response = await client.PostAsync(message.ApiAddress, message.Content);
                if (response.IsSuccessStatusCode)
                {
                    StoreResponse(response.Content.ReadAsStringAsync());
                }
                else
                {
                    MessageBox.Show(
                        "Wystąpił bład podczas wysyłki danych do API DevOps!\n" + response.StatusCode, "Błąd!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void StoreResponse(Task<string> responseBody)
        {
            DatabaseOperations db = new DatabaseOperations();
            db.Insert(DataMapper.MapResponse(responseBody));
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

        private Uri GetUriAddress()
        {
            return new Uri(DatabaseOperations.GetUriAddress(Project));
        }
    }
}
