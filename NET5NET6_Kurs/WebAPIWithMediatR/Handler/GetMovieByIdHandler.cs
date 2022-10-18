using MediatR;
using WebAPIWithMediatR.Data;
using WebAPIWithMediatR.Models;
using WebAPIWithMediatR.Queries;

namespace WebAPIWithMediatR.Handler
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMovieByIdHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetMovieById(request.Id);
        }
    }
}
