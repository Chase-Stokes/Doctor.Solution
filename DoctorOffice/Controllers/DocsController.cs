using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorOffice.Controllers
{
  public class DocsController : Controller 
  {
    private readonly DoctorOfficeContext _db;

    public  DocsController(DoctorOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Doc> model = _db.Docs.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doc doc)
    {
      _db.Docs.Add(doc);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDoc = _db.Docs
        .Include(doc => doc.JoinEntities)
        .ThenInclude(join => join.Patient)
        .FirstOrDefault(doc => doc.DocId == id);
      return View(thisDoc);  
    }

    public ActionResult Edit(int id)
    {
      var thisDoc = _db.Docs.FirstOrDefault(doc => doc.DocId == id);
      return View(thisDoc);
    }

    [HttpPost]
    public ActionResult Edit(Doc doc)
    {
      _db.Entry(doc).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisDoc = _db.Docs.FirstOrDefault(doc => doc.DocId == id);
      return View(thisDoc);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoc = _db.Docs.FirstOrDefault(doc => doc.DocId == id);
      _db.Docs.Remove(thisDoc);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}