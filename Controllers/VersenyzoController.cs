using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EuroSkills.Data;
using EuroSkills.Models;

namespace EuroSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VersenyzoController : ControllerBase
    {
        private readonly VersenyDbContext _context;

        public VersenyzoController(VersenyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Versenyzo>>> GetVersenyzok()
        {
            return await _context.Versenyzok.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Versenyzo>> GetVersenyzo(string id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);

            if (versenyzo == null)
            {
                return NotFound();
            }

            return versenyzo;
        }

        [HttpPost]
        public async Task<ActionResult> AddVersenyzo(Versenyzo versenyzo)
        {
            _context.Versenyzok.Add(versenyzo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult> UpdateVersenyzo(int id, Versenyzo updatedData)
        {
            var versenyzo = _context.Versenyzok.FirstOrDefault(p => p.Id == id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            if (updatedData.Id >= 0) versenyzo.Id = updatedData.Id;
            if (updatedData.Nev == null) versenyzo.Nev = updatedData.Nev;
            if (updatedData.OrszagId == null) versenyzo.OrszagId = updatedData.OrszagId;
            if (updatedData.SzakmaId == null) versenyzo.SzakmaId = updatedData.SzakmaId;
            return Ok(versenyzo);
        }
    }
}
