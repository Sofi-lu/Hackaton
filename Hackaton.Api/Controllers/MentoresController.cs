using Microsoft.AspNetCore.Mvc;
using Hackaton.Shared.Enties;
using Microsoft.EntityFrameworkCore;
using Hackaton.Api.Data;

namespace Hackaton.Api.Controllers
{
    [ApiController]
    [Route("/api/mentores")]

    public class MentoresController : ControllerBase
    {
        private readonly DataContext _context;
        public MentoresController(DataContext context)
        {
            _context = context;
        }


        // Get por lista
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Mentores.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {
            var mentor = await _context.Mentores.FirstOrDefaultAsync(x => x.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mentor);
            }
        }

        //Post- insertar 
        [HttpPost]

        public async Task<ActionResult> Post(Mentor mentor)
        {
            _context.Add(mentor);
            await _context.SaveChangesAsync();

            return Ok(mentor);

        }

        //Put- modificar
        [HttpPut]

        public async Task<ActionResult> Put(Mentor mentor)
        {
            _context.Update(mentor);
            await _context.SaveChangesAsync();

            return Ok(mentor);

        }
        // Delete 
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Mentores
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}