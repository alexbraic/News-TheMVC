
using News.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using News.Data.Migrations;

namespace News.Services
{
    public class ReportsService
    {
        public HttpClient Client { get; set; }
        public ReportsService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://localhost:7290/");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }

        public async Task<IEnumerable<Models.Report>> GetReportList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Models.Report>>("/api/Reports");
        }
    }
}
