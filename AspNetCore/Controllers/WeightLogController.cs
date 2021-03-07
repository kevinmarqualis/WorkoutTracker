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

        [HttpGet("{id}")]
        public async Task<ActionResult<WeightLog>> GetAction(string id)
        {
            return await _dbContext.WeightLogs.FindAsync(id);
        }

        [HttpPost]
        public async Task Post(WeightLog model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, WeightLog model)
        {
            var exists = await _dbContext.WeightLogs.AnyAsync(f => f.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.WeightLogs.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _dbContext.WeightLogs.FindAsync(id);

            _dbContext.WeightLogs.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
