using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_Server.Models;

namespace PRS_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestlinesController : ControllerBase
    {
        private readonly PRSDatabaseContext _context;

        public RequestlinesController(PRSDatabaseContext context)
        {
            _context = context;
        }

        private async Task<IActionResult> RecalculateRequest(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null)
            {
                return NotFound();
            }
            request.Total = (from r in _context.Requestlines
                    join p in _context.Products
                    on r.ProductId equals p.Id
                    where r.RequestId == requestId
                    select new
                        {RequestLinesTotal = r.Quantity * p.Price}).Sum(x => x.RequestLinesTotal);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestline>>> GetRequestlines()
        {
            return await _context.Requestlines.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Requestline>> GetRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);

            if (requestline == null)
            {
                return NotFound();
            }

            return requestline;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestline(int id, Requestline requestline)
        {
            if (id != requestline.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestlineExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Requestline>> PostRequestline(Requestline requestline)
        {
            _context.Requestlines.Add(requestline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestline", new { id = requestline.Id }, requestline);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);
            if (requestline == null)
            {
                return NotFound();
            }

            _context.Requestlines.Remove(requestline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestlineExists(int id)
        {
            return _context.Requestlines.Any(e => e.Id == id);
        }
    }
}
