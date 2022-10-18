using MediatR;
using WebAPIWithMediatR.Commands;
using WebAPIWithMediatR.Data;
using WebAPIWithMediatR.Models;

namespace WebAPIWithMediatR.Handler
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;
        private readonly IMediator _mediator;

        public AddMovieCommandHandler(FakeDataStore fakeDataStore,  IMediator mediator)
        {
            _fakeDataStore = fakeDataStore;
            _mediator = mediator;
        }

        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddMovie(request.Movie);

            //await _mediator.Publish(new MovieAddedNotification(movieWithId));
            return request.Movie;
        }
    }
}
