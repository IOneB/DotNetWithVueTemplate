using Microsoft.AspNetCore.Mvc;
using MongoBongo.DAL.Models.Entities;
using MongoBongo.DAL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoBongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly WorkService _workService;

        public WorkController(WorkService workService)
        {
            _workService = workService;
        }

        [HttpGet]
        public Task<List<Work>> Get()
        {
            return _workService.GetAsync();
        }

        [HttpGet("{id}", Name = "GetWork")]
        public async Task<ActionResult<Work>> Details(string id)
        {
            var work = await _workService.GetAsync(id);

            if (work is null)
                return NotFound();

            return work;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Work work)
        {
            await _workService.CreateAsync(work);

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Work workIn)
        {
            var work = await _workService.GetAsync(id);
            if (work is null)
                return NotFound();

            await _workService.UpdateAsync(id, workIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var work = await _workService.GetAsync(id);
            if (work is null)
                return NotFound();

            await _workService.RemoveAsync(work.Id);
            return NoContent();
        }
    }
}
