using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EuroSkills.Data;
using EuroSkills.Models;

namespace EuroSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrszagController : ControllerBase
    {
        private readonly VersenyDbContext _context;

        public OrszagController(VersenyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orszag>>> GetOrszagok()
        {
            return await _context.Orszagok.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Orszag>> GetOrszag(string id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);

            if (orszag == null)
            {
                return NotFound();
            }

            return orszag;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrszag(Orszag orszag)
        {
            _context.Orszagok.Add(orszag);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult> UpdateOrszag(string id, Orszag updatedData)
        {
            var orszag = _context.Orszagok.FirstOrDefault(p => p.Id == id);
            if (orszag == null)
            {
                return NotFound();
            }

            if (updatedData.Id == null) orszag.Id = updatedData.Id;
            if (updatedData.OrszagNev == null) orszag.OrszagNev = updatedData.OrszagNev;
            return Ok(orszag);
        }
    }
}