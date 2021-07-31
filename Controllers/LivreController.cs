using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP.NET_MVC.Models;
using System.IO;

namespace ASP.NET_MVC.Controllers
{
    public class LivreController : Controller
    {
        BD_BIBLIOTHEQUEEntities db = new BD_BIBLIOTHEQUEEntities();
        // GET:LIVRES
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutLivre()
        {
            try
            {
                ViewBag.listeLivre = db.LIVRES.ToList();
                ViewBag.listeAuteur = db.AUTEURS.ToList();
                ViewBag.listeGenre = db.GENRES.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutLivre(LIVRE livre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0]; //le nom de note fichier
                        if (file != null && file.ContentLength > 0)   //si notre fichierest different de null et que sa taille > 0 octet
                        {
                            var fileName = Path.GetFileName(file.FileName); //recuperer le nom du fichier
                            var path = Path.Combine(Server.MapPath("~/Fichier"), fileName); //recupererle chemin d'acces ou sera mis notre fichier
                            file.SaveAs(path);//enregistrer le tout sur le serveur

                            livre.IMAGE_LIVRE = fileName;
                            livre.URL_IMAGE_LIVRE = "/Fichier";
                        }
                    }

                    db.LIVRES.Add(livre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerLivre(int id)
        {
            try
            {
                LIVRE livre = db.LIVRES.Find(id); //recherchede Livres
                if (livre != null)
                {
                    db.LIVRES.Remove(livre); //supprimer Livres
                    db.SaveChanges();//enregistrer le resultat
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierLivre(int id)
        {
            try
            {
                ViewBag.listeAuteur = db.AUTEURS.ToList();
                ViewBag.listeGenre = db.GENRES.ToList();
                ViewBag.listeLivre = db.LIVRES.ToList();

                LIVRE livre = db.LIVRES.Find(id);
                if (livre != null)
                {
                    return View("AjoutLivre", livre);
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierLivre(LIVRE livre)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0]; //le nom de note fichier
                        if (file != null && file.ContentLength > 0)   //si notre fichierest different de null et que sa taille > 0 octet
                        {
                            var fileName = Path.GetFileName(file.FileName); //recuperer le nom du fichier
                            var path = Path.Combine(Server.MapPath("~/Fichier"), fileName); //recupererle chemin d'acces ou sera mis notre fichier
                            file.SaveAs(path);//enregistrer le tout sur le serveur

                            livre.IMAGE_LIVRE = fileName;
                            livre.URL_IMAGE_LIVRE = "/Fichier";
                        }
                    }


                    db.Entry(livre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        private LIVRE GetFileList(int id)
        {
            var DetList = db.LIVRES.Where(p => p.ID_LIVRE == id).FirstOrDefault();
            return DetList;
        }
        [HttpGet]
        public ActionResult RetrieveFile(int id)
        {
            LIVRE diagnosticDetailModel = GetFileList(id);
            //byte[] img = diagnosticDetailModel.FileContent.ToArray();
            Response.AppendHeader("Content-Disposition", "inline");
            return File("~/Fichier/" + diagnosticDetailModel.IMAGE_LIVRE, "application/pdf");

        }
    }

}