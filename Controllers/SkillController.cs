using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Services;
using VortiDex.Services.Interface;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillServ;

        public SkillController(ISkillService skillServ)
        {
            _skillServ = skillServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var skill = _skillServ.ReadAll();
            return Ok(skill);
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            try
            {
                var skill = _skillServ.ReadById(id);

                return Ok(skill);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSkillDto dto)
        {
            var skill = _skillServ.Create(dto);

            return CreatedAtAction(nameof(ReadById), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSkillDto dto)
        {
            var skill = _skillServ
               .Update(id, dto);

            return Ok(skill);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _skillServ.Delete(id);

                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
