
using News.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using News.Data.Migrations;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpPost]
        //public async Task<ActionResult<Models.Report>> PostReport(Models.Report report)
        //{
        //    HttpResponseMessage response = awaitclient.PostAsJsonAsync("api/Department");
        //    Client.Report.Add(report);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(PostReport), new { id = report.Id }, report);
        //}
    }
}
