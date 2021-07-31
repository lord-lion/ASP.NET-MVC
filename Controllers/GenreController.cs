using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP.NET_MVC.Models;
namespace ASP.NET_MVC.Controllers
{
    public class GenreController : Controller
    {
        BD_BIBLIOTHEQUEEntities db = new BD_BIBLIOTHEQUEEntities();
        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutGenre()
        {
            try
            {
                ViewBag.listeGenre = db.GENRES.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutGenre(GENRE genre)//enregistrement
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.GENRES.Add(genre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerGenre(int id)
        {
            try
            {

                //on va recherche  Genres
                GENRE genre = db.GENRES.Find(id);
                if (genre != null)
                {
                    //supprimer  Genres
                    db.GENRES.Remove(genre);
                    db.SaveChanges();//Save le resultat
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierGenre(int id)
        {
            try
            {
                ViewBag.listeGenre = db.GENRES.ToList();
                GENRE genre = db.GENRES.Find(id);
                if (genre != null)
                {
                    return View("AjoutGenre", genre);
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierGenre(GENRE genre)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}