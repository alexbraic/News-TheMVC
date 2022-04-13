using News.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace News.Services
{
    public class CommentsService
    {
        public HttpClient Client { get; set; }
        public CommentsService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://localhost:7145/");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }

        public async Task<IEnumerable<Comment>> GetReportList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Comment>>("api/Comments");
        }
    }
}
