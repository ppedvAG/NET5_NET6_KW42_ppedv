using MediatR;
using WebAPIWithMediatR.Models;

namespace WebAPIWithMediatR.Queries
{
    public record GetMoviesQuery : IRequest<IEnumerable<Movie>>;

}
