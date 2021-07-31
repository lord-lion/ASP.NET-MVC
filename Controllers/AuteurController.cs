using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Controllers
{
    public class AuteurController : Controller
    {
        BD_BIBLIOTHEQUEEntities db = new BD_BIBLIOTHEQUEEntities();
        // GET: Auteurs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutAuteur()
        {
            try
            {
                ViewBag.listeAuteur = db.AUTEURS.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutAuteur(AUTEUR auteur)//enregistrement
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.AUTEURS.Add(auteur);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerAuteur(int id)
        {
            try
            {       //on va recherche Auteurs
                AUTEUR auteur = db.AUTEURS.Find(id);
                if (auteur != null)
                {
                    //supprimer Auteurs
                    db.AUTEURS.Remove(auteur);
                    db.SaveChanges();//Save le resultat
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierAuteur(int id)
        {
            try
            {
                ViewBag.listeAuteur = db.AUTEURS.ToList();
                AUTEUR auteur = db.AUTEURS.Find(id);
                if (auteur != null)
                {
                    return View("AjoutAuteur", auteur);
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierAuteur(AUTEUR auteur)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(auteur).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}