﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using P4P.Models;

namespace P4P.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Gebruiker gebruiker)
        {
            using (var ctx = new P4PContext())
            {
                //als de code hier ergens een error oplevert voert hij catch uit.
                try
                {
                    if (gebruiker.Wachtwoord == null)
                        gebruiker.LoginToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    ctx.Gebruikers.Add(gebruiker);
                    ctx.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Message = "Something went wrong!";
                }
            }

            return View();
        }
    }
}