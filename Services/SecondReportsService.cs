using News.Data.Migrations;

namespace News.Services
{
    public class SecondReportsService
    {
        public HttpClient Client { get; set; }
        public SecondReportsService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://localhost:7151/");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }

        public async Task<IEnumerable<Report>> GetReportList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Report>>("/api/Reports");
        }
    }
}
