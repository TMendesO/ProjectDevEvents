using DevEvents.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDevEvents.API.Persistence;

namespace DevEvents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDBContext _context;
        public DevEventsController(DevEventsDBContext context)
        {
            _context = context;
        }

        //api/dev-events/ GET
        [HttpGet]
        public IActionResult GetAll()
        {
          var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();

            return Ok(devEvents);
        }

        //api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa76 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        //api/dev-events/ POST
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        //api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa7 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id,DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            return NoContent();
        }

        //api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa7 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();
            return NoContent();
        }

        //api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa7/speakers
        [HttpPost("{id}/speakers")]

        public IActionResult PostSpeaker(Guid id, DevEventSpealker speaker)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Speakers.Add(speaker);

            return NoContent();

        }



    }
}
