﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using projet_ASP.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace projet_ASP.Controllers
{
    public class LocataireController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Locataire
        public ActionResult Index(string id = "")
        {

            try
            {
                ApplicationDbContext db2 = new ApplicationDbContext();
                string id2 = User.Identity.GetUserId();
                var user = db2.Users.Where(n => n.Id == id2).FirstOrDefault();
                if (user.idListeNoire != null)
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    var listenoir = db2.ListeNoires.Where(l => l.idListeNoire == user.idListeNoire).FirstOrDefault();
                    ViewData["msg"] = listenoir.description;
                    return RedirectToAction("BlokcedUser", "Account");


                }
            }
            catch (Exception) { }
            String userId = id == "" ? User.Identity.GetUserId() : id;
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Locataires.Include(e => e.reservations).Where(item => item.ApplicationUserID == userId).FirstOrDefault();
            // int reservation = db.reservations.Where(item => item.idLocataire == prop.idLocataire).ToList().Count;
            //ViewData["nbReservation"] = reservation;
            if (prop == null) return RedirectToAction("Index", "Manage");
            return View(prop);
        }


        public JsonResult updatePhoto()
        {
            HttpPostedFileBase file = Request.Files[0];
            String userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Users.Where(item => item.Id == userId).FirstOrDefault();
            prop.imageBytes = new byte[file.ContentLength];
            file.InputStream.Read(prop.imageBytes, 0, file.ContentLength);
            db.SaveChanges();
            return Json("Uploaded " + Request.Files.Count + " files");
        }


        public JsonResult deletePhoto()
        {
            string imgPath = Server.MapPath("~/Content/profile_img.png"); //img par defaut
            String userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Users.Where(item => item.Id == userId).FirstOrDefault();
            prop.imageBytes = System.IO.File.ReadAllBytes(imgPath);
            db.SaveChanges();
            return Json("Supprimer image de profile");
        }

        public class ProfileUpdate
        {
            public string nomComplet { get; set; }
            public string Email { get; set; }
            public string adresse { get; set; }
            public string PhoneNumber { get; set; }
        }



        public JsonResult update(ProfileUpdate profile)
        {
            String userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Users.Where(item => item.Id == userId).FirstOrDefault();
            prop.Email = profile.Email;
            prop.adresse = profile.adresse;
            prop.PhoneNumber = profile.PhoneNumber;
            prop.nomComplet = profile.nomComplet;
            db.SaveChanges();
            return Json("Profile updated");
        }



        // GET: Locataire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Locataire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locataire/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locataire/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Locataire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locataire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Locataire/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
