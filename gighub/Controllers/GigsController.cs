using gighub.Models;
using gighub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gighub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs
        public ActionResult Create()    
        {
            GigFormViewModel viewModel = new GigFormViewModel

            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}