using MediatR;
using WebAPIWithMediatR.Data;
using WebAPIWithMediatR.Models;
using WebAPIWithMediatR.Queries;

namespace WebAPIWithMediatR.Handler
{
    //Handler-Klassen können alle auf den IOC Container zugreifen 
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMoviesHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return _fakeDataStore.GetAllMovies();
        }
    }
}
