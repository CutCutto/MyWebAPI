using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI;

namespace MyWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Mouth")]
    public class MouthController : Controller
    {
        private readonly EmotionContext _context;

        public MouthController(EmotionContext context)
        {
            _context = context;
        }

        // GET: api/Mouth
        [HttpGet]
        public IEnumerable<MouthModel> GetMouthModels()
        {
            return _context.MouthModels;
        }

        // GET: api/Mouth/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMouthModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mouthModel = await _context.MouthModels.SingleOrDefaultAsync(m => m.id == id);

            if (mouthModel == null)
            {
                return NotFound();
            }

            return Ok(mouthModel);
        }

        // PUT: api/Mouth/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMouthModel([FromRoute] int id, [FromBody] MouthModel mouthModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mouthModel.id)
            {
                return BadRequest();
            }

            _context.Entry(mouthModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MouthModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mouth
        [HttpPost]
        public async Task<IActionResult> PostMouthModel([FromBody] MouthModel mouthModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MouthModels.Add(mouthModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMouthModel", new { id = mouthModel.id }, mouthModel);
        }

        // DELETE: api/Mouth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMouthModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mouthModel = await _context.MouthModels.SingleOrDefaultAsync(m => m.id == id);
            if (mouthModel == null)
            {
                return NotFound();
            }

            _context.MouthModels.Remove(mouthModel);
            await _context.SaveChangesAsync();

            return Ok(mouthModel);
        }

        private bool MouthModelExists(int id)
        {
            return _context.MouthModels.Any(e => e.id == id);
        }
    }
}