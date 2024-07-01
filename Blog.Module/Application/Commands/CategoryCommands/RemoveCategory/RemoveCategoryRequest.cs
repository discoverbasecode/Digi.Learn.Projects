using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.RemoveCategory;

public record RemoveCategoryRequest(Guid Id) : IRequest<OperationResult<RemoveCategoryResponse>>;