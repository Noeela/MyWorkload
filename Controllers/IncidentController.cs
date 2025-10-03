using Microsoft.AspNetCore.Mvc;
using DisasterAlleviation.Data;
using DisasterAlleviation.Models;
using System.Linq;

namespace DisasterAlleviation.Controllers
{
    public class IncidentController : Controller
    {
        private readonly AppDbContext _db;
        public IncidentController(AppDbContext db) { _db = db; }

        // GET: /Incident/Create
        public IActionResult Create() => View(new IncidentReport());

        // POST: /Incident/Create
        [HttpPost]
        public IActionResult Create(IncidentReport model)
        {
            if (!ModelState.IsValid) return View(model);

            _db.Incidents.Add(model);
            _db.SaveChanges();

            TempData["Message"] = "Incident reported successfully.";

            // Redirect to details page of the created incident
            return RedirectToAction("Details", new { id = model.Id });
        }

        // GET: /Incident/Details/5
        public IActionResult Details(int id)
        {
            var incident = _db.Incidents.FirstOrDefault(i => i.Id == id);
            if (incident == null) return NotFound();

            return View(incident);
        }

        // GET: /Incident
        public IActionResult Index()
        {
            var incidents = _db.Incidents.ToList();
            return View(incidents);
        }
    }
}
