using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithMediatR.Commands;
using WebAPIWithMediatR.Models;
using WebAPIWithMediatR.Notifications;
using WebAPIWithMediatR.Queries;

namespace WebAPIWithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;



        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            //GetMoviesQuery -> hat einen eigenen Handler, der die Bearbeitung uns loose wegkapselt 
            IEnumerable<Movie> movies = await _mediator.Send(new GetMoviesQuery());

            return Ok(movies);
        }

        [HttpGet("{id:int}", Name = "GetMovieById")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            Movie movie = await _mediator.Send(new GetMovieByIdQuery(id));

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie(Movie movie)
        {
            Movie movieWithId = await _mediator.Send(new AddMovieCommand(movie));

            await _mediator.Publish(new MovieAddedNotification(movieWithId));

            return CreatedAtRoute("GetMovieById", new { id = movieWithId.Id }, movieWithId);
        }
    }
}
