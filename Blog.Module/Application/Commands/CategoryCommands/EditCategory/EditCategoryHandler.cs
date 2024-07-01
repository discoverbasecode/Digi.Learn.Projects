using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;
using FluentValidation;
using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.EditCategory;

public class EditCategoryHandler(
    IMapper mapper,
    IValidator<EditCategoryRequest> validator,
    ICategoryRepository repository) :
    IRequestHandler<EditCategoryRequest, OperationResult<EditCategoryResponse>>
{
    public async Task<OperationResult<EditCategoryResponse>> Handle(EditCategoryRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return OperationResult<EditCategoryResponse>.Error(validationResult.Errors.ToString()!);

        var findCategory = await repository.GetAsync(request.Id, cancellationToken);

        if (findCategory is null)
            return OperationResult<EditCategoryResponse>.NotFound();

        if (request.Slug != findCategory.Slug)
            if (await repository.ExistsAsync(c => c.Slug == request.Slug, cancellationToken))
                return OperationResult<EditCategoryResponse>.Error("Slug is Existed !");

        findCategory.Edit(request.Title, request.Title, request.Slug);

        repository.Edit(findCategory);
        await repository.Save(cancellationToken);
        return OperationResult<EditCategoryResponse>.Success(mapper.Map<EditCategoryResponse>(findCategory));
    }
}