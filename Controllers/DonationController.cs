using Microsoft.AspNetCore.Mvc;
using DisasterAlleviation.Data;
using DisasterAlleviation.Models;

namespace DisasterAlleviation.Controllers
{
    public class DonationController : Controller
    {
        private readonly AppDbContext _db;
        public DonationController(AppDbContext db) { _db = db; }

        public IActionResult Create() => View(new Donation());

        [HttpPost]
        public IActionResult Create(Donation model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Donations.Add(model);
            _db.SaveChanges();
            TempData["Message"] = "Donation recorded. Thank you!";
            return RedirectToAction("Create");
        }
    }
}
