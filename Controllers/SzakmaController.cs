using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EuroSkills.Data;
using EuroSkills.Models;

namespace EuroSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SzakmaController : ControllerBase
    {
        private readonly VersenyDbContext _context;

        public SzakmaController(VersenyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szakma>>> GetSzakmak()
        {
            return await _context.Szakmak.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Szakma>> GetSzakma(string id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);

            if (szakma == null)
            {
                return NotFound();
            }

            return szakma;
        }

        [HttpPost]
        public async Task<ActionResult> AddSzakma(Szakma szakma)
        {
            _context.Szakmak.Add(szakma);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult> UpdateSzakma(string id, Szakma updatedData)
        {
            var szakma = _context.Szakmak.FirstOrDefault(p => p.Id == id);
            if (szakma == null)
            {
                return NotFound();
            }

            if (updatedData.Id == null) szakma.Id = updatedData.Id;
            if (updatedData.SzakmaNev == null) szakma.SzakmaNev = updatedData.SzakmaNev;
            return Ok(szakma);
        }
    }
}
