using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UKAttractions.Models;
using PagedList;
using PagedList.Mvc;
using System.Net;

namespace UKAttractions.Controllers
{
    public class HomeController : Controller
    {
        private TopAttractionsEntities db = new TopAttractionsEntities();
        // GET: Home
        public ActionResult Index(string city, string searchString, int?page)
        {
            //search city
           
            var CityList = new List<string>();
            var CityQry = from d in db.CountryAttractions
                          orderby d.City
                          select d.City;
            CityList.AddRange(CityQry.Distinct());
            
            ViewBag.city = new SelectList(CityList);

            //search by name

            var attractions = from c in db.CountryAttractions
                              select c;

            if (!String.IsNullOrEmpty(city))
            {
                attractions = attractions.Where(x => x.City == city);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.Name.Contains(searchString));
                
            }
            
            return View(attractions.OrderBy(d => d.Id).ToPagedList(page??1, 4));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAttraction conAttraction = db.CountryAttractions.Find(id);
            if (conAttraction == null)
            {
                return HttpNotFound();
            }
            return View(conAttraction);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryAttraction attractions)
        {
            if (ModelState.IsValid)
            {
                db.CountryAttractions.Add(attractions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attractions);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAttraction attractions = db.CountryAttractions.Find(id);
            return View(attractions);
        }

        [HttpPost]
        public ActionResult Edit(CountryAttraction attractions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attractions).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attractions);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAttraction attractions = db.CountryAttractions.Find(id);
            return View(attractions);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryAttraction attractions = db.CountryAttractions.Find(id);
            db.CountryAttractions.Remove(attractions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SliderImages()
        {
            //search by name
            var attractions = db.CountryAttractions
                              .Select(x => new ImageSlider() { ID = x.Id, Image = x.Image })
                              .ToList();

            return View("SliderPI", attractions);
        }

    }
}