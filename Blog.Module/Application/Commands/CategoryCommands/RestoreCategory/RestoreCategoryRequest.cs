using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.RestoreCategory;

public record RestoreCategoryRequest(Guid Id) : IRequest<OperationResult<RestoreCategoryResponse>>;