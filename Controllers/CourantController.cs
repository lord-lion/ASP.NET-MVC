using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Controllers
{
    public class CourantController : Controller
    {
        BD_BIBLIOTHEQUEEntities db = new BD_BIBLIOTHEQUEEntities();
        // GET: Courants
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutCourants()
        {
            try
            {
                ViewBag.listeGenre = db.GENRES.ToList();
                ViewBag.listeCourant = db.COURANTS.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutCourants(COURANT courant)//enregistrement
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.COURANTS.Add(courant);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCourants");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerCourant(int id)
        {
            try
            {       //on va recherche Courant
                COURANT courant = db.COURANTS.Find(id);
                if (courant != null)
                {
                    //supprimer Courant
                    db.COURANTS.Remove(courant);
                    db.SaveChanges();//Save le resultat
                }
                return RedirectToAction("AjoutCourants");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierCourant(int id)
        {
            try
            {
                ViewBag.listeGenre = db.GENRES.ToList();
                ViewBag.listeCourant = db.COURANTS.ToList();
                COURANT courant = db.COURANTS.Find(id);
                if (courant != null)
                {
                    return View("AjoutCourants", courant);
                }
                return RedirectToAction("AjoutCourants");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierCourant(COURANT courant)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(courant).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCourants");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}