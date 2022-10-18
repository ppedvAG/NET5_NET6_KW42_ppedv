using MediatR;
using WebAPIWithMediatR.Models;

namespace WebAPIWithMediatR.Commands
{
    public record AddMovieCommand(Movie Movie) : IRequest<Movie>;
   
}
