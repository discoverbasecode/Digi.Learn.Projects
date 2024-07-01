using Blog.Module.Domain.CategoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Blog.Module.Application.Commands.CategoryCommands.EditCategory;
public record EditCategoryNotification(Category Category) : INotification;


public class EditCategoryNotificationHandler(ILogger<EditCategoryNotificationHandler> logger) : INotificationHandler<EditCategoryNotification>
{
    public Task Handle(EditCategoryNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Category Title : [ {notification.Category.Title} ] Edited To DataBase--- DateTime : {DateTime.Now}");
        return Task.CompletedTask;

    }
}
