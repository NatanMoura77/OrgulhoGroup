using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Services;

namespace VortiDex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly SquadServices _squadServ;

        public SquadController(SquadServices squadServ)
        {
            _squadServ = squadServ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var squad = _squadServ.GetAllServ();
            return Ok(squad);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var squad = _squadServ.GetById(id);

            return Ok(squad);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSquadDto dto)
        {
            var squad = _squadServ.CreateServ(dto);

            return CreatedAtAction(nameof(GetById), new { id = squad.Id }, squad);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSquadDto dto)
        {
            var squad = _squadServ
               .UpdateServ(id, dto);

            return Ok(squad);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _squadServ
                .Delete(id);

            return NoContent();
        }
    }
}
