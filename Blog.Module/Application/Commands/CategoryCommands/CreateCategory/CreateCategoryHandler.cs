using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;
using FluentValidation;
using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.CreateCategory;

public class CreateCategoryHandler(
    IMapper mapper,
    IValidator<CreateCategoryRequest> validator,
    ICategoryRepository repository) :
    IRequestHandler<CreateCategoryRequest, OperationResult<CreateCategoryResponse>>
{
    public async Task<OperationResult<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return OperationResult<CreateCategoryResponse>.Error(validationResult.Errors.ToString()!);

        if (await repository.ExistsAsync(c => c.Slug == request.Slug, cancellationToken))
            return OperationResult<CreateCategoryResponse>.Error("دسته بندی  بلاگ تکراری است");

        var createCategory = Category.Create(request.Title, request.Icon, request.Slug);

        await repository.AddAsync(createCategory, cancellationToken);
        await repository.Save(cancellationToken);

        return OperationResult<CreateCategoryResponse>.Success(mapper.Map<CreateCategoryResponse>(createCategory));
    }
}