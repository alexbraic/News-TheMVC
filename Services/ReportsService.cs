
using News.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

using News.Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Mvc;

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
        //public async Task<ActionResult> Create(Models.Report report, Uri uri)
        //{


        //    var response = await Client.PostAsJsonAsync("https://localhost:7290/api/Reports", report);
        //    if (response.IsSuccessStatusCode)
        //    {

        //        return (ActionResult)await Client.GetFromJsonAsync<IEnumerable<Models.Report>>("/api/Reports");
        //    }
        //    //return View("Error");
        //    return (ActionResult)await Client.GetFromJsonAsync<IEnumerable<Models.Report>>("/api/Reports");
        //}

        
    }
}
