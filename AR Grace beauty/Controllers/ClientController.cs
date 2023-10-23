using GalanjBarberShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalanjBarberShop.Controllers;

public class ClientController : Controller
{
    public readonly ApplicationDbContext _db;
    public ClientController(ApplicationDbContext db) => _db = db;

    public IActionResult Index()
    {
        List<Client> clientList = _db.Client.ToList();
        return View(clientList);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Client client)
    {
        if (ModelState.IsValid)
        {
            _db.Client.Add(client);
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

        Client? clientFromDb = _db.Client.Find(id);
        if (clientFromDb == null)
        {
            return NotFound();
        }
        return View(clientFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Client client)
    {
        if (ModelState.IsValid)
        {
            _db.Client.Update(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        Client? clientFromDb = _db.Client.Find(id);
        if (clientFromDb == null)
        {
            return NotFound();
        }
        _db.Client.Remove(clientFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
