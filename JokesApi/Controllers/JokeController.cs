using AutoMapper;
using JokesApi.Dtos;
using JokesApi.Models;
using JokesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JokesApi.Controllers
{
    [Route("api/v1/jokes")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private readonly IJokeService _jokeService;
        private readonly IMapper _mapper;

        public JokeController(IJokeService jokeService, IMapper mapper)
        {
            _jokeService = jokeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateJoke([FromBody] JokeRequestDto requestJoke)
        {
            try
            {
                var joke = _mapper.Map<Joke>(requestJoke);
                await _jokeService.CreateJokeAsync(joke);
                return Created(nameof(CreateJoke), joke);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create joke: {ex.Message}");
            }
        }

        [HttpGet("{jokeId}")]
        public async Task<ActionResult> GetJokeById(int jokeId)
        {
            try
            {
                var joke = await _jokeService.GetSingleJokeAsync(jokeId);
                if (joke == null)
                    return NotFound();

                return Ok(joke);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve joke: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllJokes()
        {
            try
            {
                var jokes = await _jokeService.GetAllJokesAsync();
                return Ok(jokes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve jokes: {ex.Message}");
            }
        }

        [HttpPut("{jokeId}")]
        public async Task<ActionResult> UpdateJoke(int jokeId, [FromBody] JokeRequestDto requestJoke)
        {
            try
            {
                var joke = _mapper.Map<Joke>(jokeId);
                await _jokeService.UpdateJokeAsync(jokeId, joke);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update joke: {ex.Message}");
            }
        }

        [HttpDelete("{jokeId}")]
        public async Task<ActionResult> DeleteJoke(int jokeId)
        {
            try
            {
                await _jokeService.DeleteJokeAsync(jokeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete joke: {ex.Message}");
            }
        }
    }
}
