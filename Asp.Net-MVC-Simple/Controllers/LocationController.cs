using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Asp.Net_MVC_Simple.Models;

namespace Asp.Net_MVC_Simple.Controllers
{

    //Note : For the demo data persistance in session!.

    public class LocationController : Controller
    {

        // GET: Location
        public ActionResult Index()
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations != null) return View(locations);

            System.Web.HttpContext.Current.Session["locations"] = Data.TestData.LocationData();
            return View(Data.TestData.LocationData());
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations == null) return RedirectToAction("Index");
            var location = locations.FirstOrDefault(l => l.Id == id);
            return View(location);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View(new LocationViewModel());
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            var newId = new Random(100).Next();
            var newLocation = new LocationViewModel { Id = newId, Title = "New Location" };
            locations?.Add(newLocation);

            return RedirectToAction("Index");

        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations == null) return RedirectToAction("Index");
            var location = locations.FirstOrDefault(l => l.Id == id);
            return View(location);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LocationViewModel model)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations == null) return RedirectToAction("Index");
            var location = locations.FirstOrDefault(l => l.Id == id);
            if (location == null) return View();

            location.Title = model.Title;
            return RedirectToAction("Index");
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations == null) return RedirectToAction("Index");
            var location = locations.FirstOrDefault(l => l.Id == id);
            return View(location);
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LocationViewModel model)
        {
            var locations = System.Web.HttpContext.Current.Session["locations"] as List<LocationViewModel>;
            if (locations == null) return RedirectToAction("Index");
            var location = locations.FirstOrDefault(l => l.Id == id);
            if (location == null) return View();

            locations.Remove(location);
            return RedirectToAction("Index");
        }
    }
}
