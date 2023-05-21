using AR_Grace_beauty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AR_Grace_beauty.Controllers
{
    public class RegistrationController : Controller
    {
        public readonly ApplicationDbContext _db;
        public RegistrationController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Registration> registrationList = _db.Registration.Include(u => u.TypeService).ThenInclude(u => u.Service).Include(u => u.Client).Include(u => u.Worker).ToList();
            return View(registrationList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> TypeServiceList = _db.TypeService.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.TypeServiceList = TypeServiceList;

            IEnumerable<SelectListItem> ClientList = _db.Client.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ClientList = ClientList;

            IEnumerable<SelectListItem> WorkerList = _db.Worker.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.WorkerList = WorkerList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _db.Registration.Add(registration);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Registration? registrationFromDb = _db.Registration.Find(id);
            if (registrationFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> TypeServiceList = _db.TypeService.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.TypeServiceList = TypeServiceList;

            IEnumerable<SelectListItem> ClientList = _db.Client.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ClientList = ClientList;

            IEnumerable<SelectListItem> WorkerList = _db.Worker.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.WorkerList = WorkerList;

            return View(registrationFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _db.Registration.Update(registration);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Registration? registrationFromDb = _db.Registration.Find(id);
            if (registrationFromDb == null)
            {
                return NotFound();
            }
            _db.Registration.Remove(registrationFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
