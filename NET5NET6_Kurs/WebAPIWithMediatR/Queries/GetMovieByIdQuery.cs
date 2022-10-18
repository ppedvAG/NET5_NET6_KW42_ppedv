using MediatR;
using WebAPIWithMediatR.Models;

namespace WebAPIWithMediatR.Queries
{
    public record GetMovieByIdQuery(int Id) : IRequest<Movie>;
    
}
