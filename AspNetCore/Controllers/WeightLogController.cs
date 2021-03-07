using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightLogController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public WeightLogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeightLog>>> Get()
        {
            return await _dbContext.WeightLogs.ToListAsync();
        }

        [HttpGet("{dateTime}")]
        public async Task<ActionResult<WeightLog>> GetAction(DateTime dateTime)
        {
            return await _dbContext.WeightLogs.FindAsync(dateTime);
        }

        [HttpPost]
        public async Task Post(WeightLog model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPut("{dateTime}")]
        public async Task<ActionResult> Put(DateTime dateTime, WeightLog model)
        {
            var exists = await _dbContext.WeightLogs.AnyAsync(f => f.Date == dateTime);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.WeightLogs.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{dateTime}")]
        public async Task<ActionResult> Delete(string dateTime)
        {
            var entity = await _dbContext.WeightLogs.FindAsync(dateTime);

            _dbContext.WeightLogs.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
