using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobAppTracker.Demo.Model;

namespace JobAppTracker.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTrackersController : ControllerBase
    {
        private readonly JobTrackerContext _context;

        public JobTrackersController(JobTrackerContext context)
        {
            _context = context;
        }

        // GET: api/JobTrackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTracker>>> GetJobTrackerItems()
        {
          if (_context.JobTrackerItems == null)
          {
              return NotFound();
          }
            return await _context.JobTrackerItems.ToListAsync();
        }

        // GET: api/JobTrackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTracker>> GetJobTracker(long id)
        {
          if (_context.JobTrackerItems == null)
          {
              return NotFound();
          }
            var jobTracker = await _context.JobTrackerItems.FindAsync(id);

            if (jobTracker == null)
            {
                return NotFound();
            }

            return jobTracker;
        }

        // PUT: api/JobTrackers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTracker(long id, JobTracker jobTracker)
        {
            if (id != jobTracker.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTrackerExists(id))
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

        // POST: api/JobTrackers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobTracker>> PostJobTracker(JobTracker jobTracker)
        {
          if (_context.JobTrackerItems == null)
          {
              return Problem("Entity set 'JobTrackerContext.JobTrackerItems'  is null.");
          }
            _context.JobTrackerItems.Add(jobTracker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobTracker), new { id = jobTracker.Id }, jobTracker);
        }

        // DELETE: api/JobTrackers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTracker(long id)
        {
            if (_context.JobTrackerItems == null)
            {
                return NotFound();
            }
            var jobTracker = await _context.JobTrackerItems.FindAsync(id);
            if (jobTracker == null)
            {
                return NotFound();
            }

            _context.JobTrackerItems.Remove(jobTracker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTrackerExists(long id)
        {
            return (_context.JobTrackerItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
