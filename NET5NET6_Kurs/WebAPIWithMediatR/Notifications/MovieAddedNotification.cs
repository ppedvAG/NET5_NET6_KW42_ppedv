using MediatR;
using WebAPIWithMediatR.Models;

namespace WebAPIWithMediatR.Notifications
{
    public record MovieAddedNotification(Movie Movie) : INotification;
}
