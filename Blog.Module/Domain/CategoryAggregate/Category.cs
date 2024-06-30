﻿using Blog.Module.Domain.PostAggregate;
using Framework.Core.Domain.Entities;

namespace Blog.Module.Domain.CategoryAggregate;

public class Category : BaseEntity
{
    public string Title { get; private set; }
    public string Icon { get; private set; }
    public string Slug { get; private set; }

    public ICollection<Post> Posts { get; } = new List<Post>();


    private Category(string title, string icon, string slug)
    {
        Title = title;
        Icon = icon;
        Slug = slug;
    }

    public static Category Create(string title, string icon, string slug)
    {
        return new Category(title, icon, slug);
    }

}