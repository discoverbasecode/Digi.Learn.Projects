using Blog.Module.Domain.CategoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Blog.Module.Application.Commands.CategoryCommands.RemoveCategory;

public record RemoveCategoryNotification(Category Category) : INotification;

public class RemoveCategoryNotificationHandler(ILogger<RemoveCategoryNotificationHandler> logger) : INotificationHandler<RemoveCategoryNotification>
{
    public Task Handle(RemoveCategoryNotification notification, CancellationToken cancellationToken)
    {
        logger.LogWarning($"Note That Physical Deletion Does Not Happen Only Change Of Status Happens !");
        logger.LogInformation($"Category By Title : [ {notification.Category.Title} ] Removed At DataBase --- DateTime : {DateTime.Now}");
        return Task.CompletedTask;
    }
}