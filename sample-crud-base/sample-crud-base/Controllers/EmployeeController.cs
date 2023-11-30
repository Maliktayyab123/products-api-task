using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sample_crud_base.Models;

namespace sample_crud_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Authenticated with Jwt";
        }
        [HttpGet]
        [Route("Details")]
        public string Details() {

            return "Authenticated with JWT";
        }
        [Authorize]
        [HttpPost]
        public string AddUsers(Users user)
        {
            return "User added with username " + user.Username;
        }
    
    }
}
