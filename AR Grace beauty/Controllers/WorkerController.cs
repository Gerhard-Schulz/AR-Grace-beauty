using AR_Grace_beauty.Models;
using Microsoft.AspNetCore.Mvc;

namespace AR_Grace_beauty.Controllers
{
    public class WorkerController : Controller
    {
        public readonly ApplicationDbContext _db;
        public WorkerController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Worker> workerList = _db.Worker.ToList();
            return View(workerList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Worker.Add(worker);
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

            Worker? workerFromDb = _db.Worker.Find(id);
            if (workerFromDb == null)
            {
                return NotFound();
            }
            return View(workerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Worker.Update(worker);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Worker? workerFromDb = _db.Worker.Find(id);
            if (workerFromDb == null)
            {
                return NotFound();
            }
            _db.Worker.Remove(workerFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
