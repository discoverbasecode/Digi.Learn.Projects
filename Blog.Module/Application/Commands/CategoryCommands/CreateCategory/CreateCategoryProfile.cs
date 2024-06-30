using AutoMapper;
using Blog.Module.Domain.CategoryAggregate;

namespace Blog.Module.Application.Commands.CategoryCommands.CreateCategory;

public class CreateCategoryProfile : Profile
{
    public CreateCategoryProfile() => CreateMap<Category, CreateCategoryResponse>(MemberList.Destination);
    public override string ProfileName => nameof(CreateCategoryProfile);
}