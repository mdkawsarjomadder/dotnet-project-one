using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using dotnet_project_one.models;
using dotnet_project_one.DTOs;
namespace dotnet_project_one.Services
{
    public class CategoryServices
    {
     private static readonly List<Category> Categories = new List<Category>();
      public List<CreateCategoryReadDto> ServicesInGetCategories()
    {
      return Categories.Select(c => new CreateCategoryReadDto{
        CategoryId = c.CategoryId,
        Name = c.Name,
        Description = c.Description,
        CreateTime = c.CreateTime
        }).ToList();

     
    }
}
}