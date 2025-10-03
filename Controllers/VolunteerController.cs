using Microsoft.AspNetCore.Mvc;
using DisasterAlleviation.Data;
using DisasterAlleviation.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DisasterAlleviation.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly AppDbContext _context;
        public VolunteerController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var volunteers = await _context.Volunteers.ToListAsync();
            return View(volunteers);
        }

        
        public IActionResult Signup() => View(new Volunteer());

        [HttpPost]
        public async Task<IActionResult> Signup(Volunteer model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Volunteers.Add(model);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Thanks for signing up!";
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Tasks()
        {
            var tasks = await _context.VolunteerTasks
                .Include(t => t.Assignments)
                .ThenInclude(a => a.Volunteer)
                .ToListAsync();
            return View(tasks);
        }

        // Volunteer signs up for a task
        [HttpPost]
        public async Task<IActionResult> Assign(int taskId, int volunteerId)
        {
            var assignment = new TaskAssignment
            {
                TaskId = taskId,
                VolunteerId = volunteerId
            };
            _context.TaskAssignments.Add(assignment);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyTasks", new { volunteerId });
        }

        // My tasks (volunteer’s own assignments)
        public async Task<IActionResult> MyTasks(int volunteerId)
        {
            var tasks = await _context.TaskAssignments
                .Include(a => a.Task)
                .Where(a => a.VolunteerId == volunteerId)
                .ToListAsync();

            return View(tasks);
        }

        
        [HttpPost]
        public async Task<IActionResult> Complete(int assignmentId)
        {
            var assignment = await _context.TaskAssignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                assignment.IsCompleted = true;
                await _context.SaveChangesAsync();
                return RedirectToAction("MyTasks", new { volunteerId = assignment.VolunteerId });
            }
            return NotFound();
        }

        
        public async Task<IActionResult> Manage()
        {
            var tasks = await _context.VolunteerTasks
                .Include(t => t.Assignments)
                .ThenInclude(a => a.Volunteer)
                .ToListAsync();
            return View(tasks);
        }

        // Create new task
        public IActionResult Create() => View(new VolunteerTask());

        [HttpPost]
        public async Task<IActionResult> Create(VolunteerTask model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.VolunteerTasks.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Manage");
        }

        // Edit task
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.VolunteerTasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VolunteerTask model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.VolunteerTasks.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Manage");
        }

        // Delete task
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.VolunteerTasks.FindAsync(id);
            if (task != null)
            {
                _context.VolunteerTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Manage");
        }


        [HttpPost]
        public async Task<IActionResult> AssignVolunteer(int taskId, int volunteerId)
        {
            var assignment = new TaskAssignment
            {
                TaskId = taskId,
                VolunteerId = volunteerId
            };
            _context.TaskAssignments.Add(assignment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Manage");
        }
    }
}
