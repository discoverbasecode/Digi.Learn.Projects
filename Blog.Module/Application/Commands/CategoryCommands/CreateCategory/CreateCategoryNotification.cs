using Blog.Module.Domain.CategoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Blog.Module.Application.Commands.CategoryCommands.CreateCategory;

public record CreateCategoryNotification(Category Category) : INotification;

public class CreateCategoryNotificationHandler(ILogger<CreateCategoryNotificationHandler> logger) : INotificationHandler<CreateCategoryNotification>
{
    public Task Handle(CreateCategoryNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Category Title : [ {notification.Category.Title} ] Added To DataBase--- DateTime : {DateTime.Now}");
        return Task.CompletedTask;

    }
}
