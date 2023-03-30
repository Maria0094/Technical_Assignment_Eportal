using E_portal_API.Models;
using E_portal_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_portal_API.Controllers
{
    public class UserController : ApiController
    {
       
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            var _userService = new UserService();
            try
            {
                var user = _userService.GetDashboard(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        
        }

        // POST: api/User
        public IHttpActionResult Post(LoginRequestModel req)
        {
            try
            {
                var _userService = new UserService();
                var authenticatedUser = _userService.Authenticate(req);
                if (authenticatedUser == null)
                {
                    return Unauthorized();
                }
                
                return Ok(authenticatedUser);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
