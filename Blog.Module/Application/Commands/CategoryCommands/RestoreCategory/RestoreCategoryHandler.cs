using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;
using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.RestoreCategory;

public class RestoreCategoryHandler(
    IMapper mapper,
    ICategoryRepository repository) :
    IRequestHandler<RestoreCategoryRequest, OperationResult<RestoreCategoryResponse>>
{
    public async Task<OperationResult<RestoreCategoryResponse>> Handle(RestoreCategoryRequest request, CancellationToken cancellationToken)
    {

        var findCategory = await repository.GetAsync(request.Id, cancellationToken);
        if (findCategory is null) return OperationResult<RestoreCategoryResponse>.NotFound();

        findCategory.Restore();

        repository.Edit(findCategory);

        await repository.Save(cancellationToken);

        return OperationResult<RestoreCategoryResponse>.Success(mapper.Map<RestoreCategoryResponse>(findCategory));

    }
}