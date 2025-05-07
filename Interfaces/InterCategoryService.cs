using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using dotnet_project_one.DTOs;

namespace dotnet_project_one.Interfaces
{
    public interface InterCategoryService
    {
            List<CreateCategoryReadDto> ServicesInGetCategories();
            CreateCategoryReadDto? GetCategoryById(Guid categoryId);
            CreateCategoryReadDto CreateCategoryPost(CreateCategoryDTO CategoryInData);
            CreateCategoryReadDto? UpdateCategoryPost( Guid categoryId ,CreateCategoryUpdateDto CategoryInData);
            bool DeleteCategoryPost(Guid categoryId);

    }
}