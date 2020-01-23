﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom_Identity.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    public class AdminController : Controller
    { 
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult AssignRole()
        {
            return View();
        }
    }
}