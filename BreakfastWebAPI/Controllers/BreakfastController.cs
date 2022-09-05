using Breakfast.Breakfast;
using BreakfastWebAPI.Models;
using BreakfastWebAPI.Services.Breakfast;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakfastWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {

        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new BreakfastModel(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
                );

            _breakfastService.CreateBreakFast(breakfast);

            var response = new BreakfastResponse()
            {
                Id = breakfast.Id,
                Sweet = breakfast.Sweet,
                Description = breakfast.Description,
                Savory = breakfast.Savory,
                StartDateTime = breakfast.StartDateTime,
                EndDateTime = breakfast.EndDateTime,
                LastModifiedTime = breakfast.LastModifiedTime,
                Name = breakfast.Name,
            };
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: response);
        }
        [HttpGet]
        public IActionResult GetBreakfasts()
        {
            var breakfasts = _breakfastService.GetBreakfasts();
            return Ok(breakfasts);
        }

        [HttpGet("/{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var breakfast = _breakfastService.GetBreakfast(id);

            var response = new BreakfastResponse()
            {
                Id = breakfast.Id,
                Description = breakfast.Description,
                EndDateTime = breakfast.EndDateTime,
                LastModifiedTime = breakfast.LastModifiedTime,
                Name = breakfast.Name,
                Savory = breakfast.Savory,
                StartDateTime = breakfast.StartDateTime,
                Sweet = breakfast.Sweet,
            };

            return Ok(response);
        }
        [HttpPut("/{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            var breakfast = new BreakfastModel(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            _breakfastService.UpsertBreakfast(breakfast);

            return NoContent();
           
        }
        [HttpDelete("/{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            _breakfastService.DeleteBreakfast(id);
            return NoContent();
        }

    }
}
