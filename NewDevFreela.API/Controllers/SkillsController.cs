using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewDevFreela.API.Entities;
using NewDevFreela.API.Models;
using NewDevFreela.API.Persistence;

namespace NewDevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly NewDevFreelaDbContext _context;
        public SkillsController(NewDevFreelaDbContext context)
        {
            _context = context;
        }

        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
