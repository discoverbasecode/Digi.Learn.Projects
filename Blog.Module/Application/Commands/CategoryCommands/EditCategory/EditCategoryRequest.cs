using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.EditCategory;

public record EditCategoryRequest(Guid Id , string Title , string Slug) : IRequest<OperationResult<EditCategoryResponse>>;