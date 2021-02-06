using gighub.Models;
using gighub.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace gighub.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
           
        }



        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {

            var userid = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FolloweeId == userid && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following Alredy Exist.");
            var following = new Following
            {
                FollowersId = userid,
                FolloweeId = dto.FolloweeId

            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}
