using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSkill;
using VortiDex.Handlers;
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
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSkillDto dto)
        {
            try
            {
                var skill = _skillServ.Create(dto);

                return CreatedAtAction(nameof(ReadById), new { id = skill.Id }, skill);
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSkillDto dto)
        {
            try
            {
                var skill = _skillServ
                   .Update(id, dto);

                return Ok(skill);

            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _skillServ.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return ControllerExceptionHandler.HandleException(exception);
            }
        }
    }
}
