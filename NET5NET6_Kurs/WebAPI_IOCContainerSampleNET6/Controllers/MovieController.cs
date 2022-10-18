using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_IOCContainerSampleNET6.Data;
using WebAPI_IOCContainerSampleNET6.Models;

namespace WebAPI_IOCContainerSampleNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieDbContext _context;

        //MovieDBContext wird aus IOC Container geladen (Konstruktor Injection) 
        public MovieController(MovieDbContext context)
        {
            _context = context;
        }




        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }


        [HttpPost ("AddMovie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            //Hinzufügen von Movie
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();


            //lesen das erstellte Movie mit Id gleich aus
            return CreatedAtAction("GetMovieById", new { id = movie.Id }, movie);
        }


        [HttpPut ("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie )
        {
            if (movie.Id != id)
            {
                return NotFound($"Movie mit der Id {movie.Id} ist nicht mit Query-Parameter-Id {id} gleich");
            }

            //Markieren Objekt, dass dieses bearbeitet wurde
            _context.Entry(movie).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                //... 
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }





    }

}
