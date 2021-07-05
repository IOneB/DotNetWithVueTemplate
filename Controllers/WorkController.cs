using Microsoft.AspNetCore.Mvc;
using MongoBongo.Models;
using MongoBongo.Services;
using System.Collections.Generic;

namespace MongoBongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return 90;
        }
    }


    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly WorkService _workService;

        public WorkController(WorkService workService)
        {
            this._workService = workService;
        }

        [HttpGet]
        public ActionResult<List<Work>> Get()
        {
            return _workService.Get();
        }

        [HttpGet("{id}", Name = "GetWork")]
        public ActionResult<Work> Details(string id)
        {
            var work = _workService.Get(id);

            if (work is null)
                return NotFound();

            return work;
        }

        [HttpPost]
        public ActionResult Create(Work work)
        {
            _workService.Create(work);

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Work workIn)
        {
            var work = _workService.Get(id);

            if (work is null)
                return NotFound();

            _workService.Update(id, workIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var work = _workService.Get(id);
            if (work is null)
                return NotFound();

            _workService.Remove(work.Id);
            return NoContent();
        }
    }
}
