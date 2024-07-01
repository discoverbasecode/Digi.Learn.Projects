using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.RemoveCategory;

public record RemoveCategoryRequest(Guid Id, string Title, string Icon, string Slug) : IRequest<OperationResult<RemoveCategoryResponse>>;