using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Services;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly SkillServices _skillServ;

        public SkillController(SkillServices skillServ)
        {
            _skillServ = skillServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var skill = _skillServ.GetAllServ();
            return Ok(skill);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var skill = _skillServ.GetById(id);

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSkillDto dto)
        {
            var skill = _skillServ.CreateServ(dto);

            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSkillDto dto)
        {
            var skill = _skillServ
               .UpdateServ(id, dto);

            return Ok(skill);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _skillServ
                .Delete(id);

            return NoContent();
        }
    }
}
