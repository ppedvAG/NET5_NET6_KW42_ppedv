using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_IOCContainerSampleNET6.Data;
using WebAPI_IOCContainerSampleNET6.Models;

namespace WebAPI_IOCContainerSampleNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))] //ApiConventionType -> löst bei jeder Http-Methode (Get, Put, Delete, Post) -> die typischen ProducesResponseType Status-Codes auf. 
    //[Consumes("application/xml")]
    public class KonvetionenController : ControllerBase
    {
        private MovieDbContext _context;
        public KonvetionenController(MovieDbContext context)
        {
            _context = context;
        }

        #region Default Konvention

        //https://localhost:12345/api/Konvetionen/HalloWelt1
        [HttpGet ("HalloWelt1")]
        public string GetHalloWelt()
            => "Hallo Welt";


        //https://localhost:12345/api/Konvetionen/HalloWelt2
        [HttpGet("HalloWelt2")]
        public string GetHalloWelt2()
            => "Hallo Welt 2";
        #endregion


        #region Movie-Action Methoden mit Konventionen

        /// <summary>
        /// Lese alle Movies aus
        /// </summary>
        /// <returns>IEnumerable<Movies></returns>
        [HttpGet("GetAllMovies")]
        [Consumes("application/xml")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Gebe Movie anhand der ID
        /// </summary>
        /// <param name="id">ID des Movies</param>
        /// <returns>Movie</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }


        [HttpPost("AddMovie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            //Hinzufügen von Movie
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();


            //lesen das erstellte Movie mit Id gleich aus
            return CreatedAtAction("GetMovieById", new { id = movie.Id }, movie);
        }


        [HttpPut("UpdateMovie")]

        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]

        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]

        // ApiConventionMethod mit DefaultApiConventions.Put -> Zeigt für Updates typische ProcedureResponseType an 
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
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
            catch (DbUpdateConcurrencyException)
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
        #endregion

    }
}
