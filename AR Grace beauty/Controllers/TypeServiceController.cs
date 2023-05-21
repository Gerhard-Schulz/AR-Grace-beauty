using AR_Grace_beauty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AR_Grace_beauty.Controllers
{
    public class TypeServiceController : Controller
    {
        public readonly ApplicationDbContext _db;
        public TypeServiceController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<TypeService> typeServiceList = _db.TypeService.Include(u => u.Service).ToList();
            return View(typeServiceList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> ServiceList = _db.Service.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ServiceList = ServiceList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(TypeService typeService)
        {
            if (ModelState.IsValid)
            {
                _db.TypeService.Add(typeService);
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

            TypeService? typeServiceFromDb = _db.TypeService.Find(id);
            if (typeServiceFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> ServiceList = _db.Service.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ServiceList = ServiceList;

            return View(typeServiceFromDb);
        }

        [HttpPost]
        public IActionResult Edit(TypeService typeService)
        {
            if (ModelState.IsValid)
            {
                _db.TypeService.Update(typeService);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            TypeService? typeServiceFromDb = _db.TypeService.Find(id);
            if (typeServiceFromDb == null)
            {
                return NotFound();
            }
            _db.TypeService.Remove(typeServiceFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
