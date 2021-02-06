﻿using gighub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gighub.Controllers
{
    public class FolloweeController : Controller
    {
        private ApplicationDbContext _context;
        public FolloweeController()
        {
             _context = new ApplicationDbContext();
        }
        // GET: Followee
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(f => f.FollowersId == userId)
                .Select(f => f.Followee)
                .ToList();
            return View(artists);
        }
    }
}