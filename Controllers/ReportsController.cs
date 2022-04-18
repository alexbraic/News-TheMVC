#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Models;
using News.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace News.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ReportsService _reportsService;
        private readonly UserManager<ApplicationIdentity> _userManager;


        // add the API context (ReportsApiService reportApiService)
        public ReportsController(ApplicationDbContext context, ReportsService reportsService /*, UserManager<ApplicationIdentity> userManager*/)
        {
            _context = context;

            // report API
            _reportsService = reportsService;
            //_userManager = userManager;
        }


        // GET: Reports
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Report.ToListAsync());

            return View(await _reportsService.GetReportList());
        }

        // GET: Reports/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            // ---------------------------------------------
            //get the movieActors model
            //var movieActors = new MovieActors();

            //var comments = await _context.Comment;
            //    .ToListAsync();

            //movieActors.Movie = movie;
            //movieActors.Actors = actors;

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }
//--------------------------------------------------------------------------------------------------------------------
        // POST: Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportName,Description,Body,CreatedBy,CreatedDate,Category")] Report report)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7290/");
                var uri = client.BaseAddress;

                var response = await client.PostAsJsonAsync(uri, report);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                //return View("Error");
                return BadRequest();
            }
        }

        //if (ModelState.IsValid)
        //{

        //    _context.Add(report);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(report);
    //}

    

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportName,Description,Body,CreatedBy,CreatedDate,LastUpdatedDate,Category")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            // get comments to show on report details page

            var reportComments = new ReportWithComments();

            var comments = await _context.Comment.ToListAsync();

            reportComments.Report = report;
            reportComments.Comment = comments;

            return View(reportComments);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Report.FindAsync(id);
            _context.Report.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.Id == id);
        }
    }
}
