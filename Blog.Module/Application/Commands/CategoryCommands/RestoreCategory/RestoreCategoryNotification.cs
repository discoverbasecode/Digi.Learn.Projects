using Blog.Module.Domain.CategoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Blog.Module.Application.Commands.CategoryCommands.RestoreCategory;

public record RestoreCategoryNotification(Category Category) : INotification;

public class RestoreCategoryNotificationHandler(ILogger<RestoreCategoryNotificationHandler> logger) : INotificationHandler<RestoreCategoryNotification>
{
    public Task Handle(RestoreCategoryNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Category By Title : [ {notification.Category.Title} ] Restored At DataBase --- DateTime : {DateTime.Now}");
        return Task.CompletedTask;
    }
}