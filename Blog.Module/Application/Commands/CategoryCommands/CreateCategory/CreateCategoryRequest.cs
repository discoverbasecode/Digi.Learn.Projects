using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.CreateCategory;

public record CreateCategoryRequest(string Title, string Icon, string Slug) : IRequest<OperationResult<CreateCategoryResponse>>;