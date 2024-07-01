using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;

namespace Blog.Module.Application.Commands.CategoryCommands.EditCategory;

public class EditCategoryProfile:Profile
{
    public EditCategoryProfile() => CreateMap<Category, EditCategoryResponse>();
    public override string ProfileName => nameof(EditCategoryProfile);

}