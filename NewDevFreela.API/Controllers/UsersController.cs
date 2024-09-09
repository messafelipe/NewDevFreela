using Microsoft.AspNetCore.Mvc;

namespace NewDevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        //POST api/users 
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
