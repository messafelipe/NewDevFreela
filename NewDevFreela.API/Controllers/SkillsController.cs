using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewDevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        //GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        //POST api/skills
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
