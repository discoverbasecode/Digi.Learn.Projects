using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;
using Framework.Core.Application.OperationResultHelpers;
using MediatR;

namespace Blog.Module.Application.Commands.CategoryCommands.RemoveCategory;

public class RemoveCategoryHandler(
    IMapper mapper,
    ICategoryRepository repository) :
    IRequestHandler<RemoveCategoryRequest, OperationResult<RemoveCategoryResponse>>
{
    public async Task<OperationResult<RemoveCategoryResponse>> Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
    {

        var findCategory = await repository.GetAsync(request.Id, cancellationToken);
        if (findCategory is null) return OperationResult<RemoveCategoryResponse>.NotFound();
        
        findCategory.Remove();
      
        repository.Edit(findCategory);
      
        await repository.Save(cancellationToken);
      
        return OperationResult<RemoveCategoryResponse>.Success(mapper.Map<RemoveCategoryResponse>(findCategory));

    }
}