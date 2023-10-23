using GalanjBarberShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalanjBarberShop.Controllers;

public class ServiceController : Controller
{
    public readonly ApplicationDbContext _db;
    public ServiceController(ApplicationDbContext db) => _db = db;

    public IActionResult Index()
    {
        List<Service> serviceList = _db.Service.ToList();
        return View(serviceList);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Service service)
    {
        if (ModelState.IsValid)
        {
            _db.Service.Add(service);
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

        Service? serviceFromDb = _db.Service.Find(id);
        if (serviceFromDb == null)
        {
            return NotFound();
        }
        return View(serviceFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Service service)
    {
        if (ModelState.IsValid)
        {
            _db.Service.Update(service);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        Service? serviceFromDb = _db.Service.Find(id);
        if (serviceFromDb == null)
        {
            return NotFound();
        }
        _db.Service.Remove(serviceFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
