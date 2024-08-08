using Microsoft.AspNetCore.Mvc;
using TvShowApi.Dtos;
using TvShowApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvShowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _service;

        public TvShowsController(ITvShowService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TvShowApiDto>>> Get()
        {
            var shows = await _service.GetAllAsync();
            return Ok(shows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TvShowApiDto>> Get(int id)
        {
            var show = await _service.GetByIdAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return Ok(show);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TvShowApiDto tvShowDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.AddAsync(tvShowDto);
                return CreatedAtAction(nameof(Get), new { id = tvShowDto.Id }, tvShowDto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TvShowApiDto tvShowDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.UpdateAsync(id, tvShowDto);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
