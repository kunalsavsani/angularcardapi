using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using angularApp.models;

namespace angularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentDetailsController : ControllerBase
    {
        private readonly paymentDetailContext _context;

        public paymentDetailsController(paymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/paymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<paymentDetails>>> GetpaymentDetails()
        {
            return await _context.paymentDetails.ToListAsync();
        }

        // GET: api/paymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<paymentDetails>> GetpaymentDetails(int id)
        {
            var paymentDetails = await _context.paymentDetails.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // PUT: api/paymentDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutpaymentDetails(int id, paymentDetails paymentDetails)
        {
            if (id != paymentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentDetailsExists(id))
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

        // POST: api/paymentDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<paymentDetails>> PostpaymentDetails(paymentDetails paymentDetails)
        {
            _context.paymentDetails.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetpaymentDetails", new { id = paymentDetails.Id }, paymentDetails);
        }

        // DELETE: api/paymentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<paymentDetails>> DeletepaymentDetails(int id)
        {
            var paymentDetails = await _context.paymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.paymentDetails.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return paymentDetails;
        }

        private bool paymentDetailsExists(int id)
        {
            return _context.paymentDetails.Any(e => e.Id == id);
        }
    }
}
