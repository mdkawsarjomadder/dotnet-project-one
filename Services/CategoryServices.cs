using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using dotnet_project_one.models;
using dotnet_project_one.DTOs;
using dotnet_project_one.Interfaces;
using AutoMapper;
namespace dotnet_project_one.Services
{
    public class CategoryServices:InterCategoryService
    {
      private static readonly List<Category> _Categories = new List<Category>();
      //!Automapper...............................!

    //?Mappper..................!
      private readonly IMapper _mapper;
      public CategoryServices(IMapper mapper){
        _mapper = mapper;
      }

    //? Get Frist part start...!
    public List<CreateCategoryReadDto> ServicesInGetCategories() //? In CategoryAllServices.. Get/categories.... strat
    {
     /* return _Categories.Select(c => new CreateCategoryReadDto{
      CategoryId = c.CategoryId,
      Name = c.Name,
      Description = c.Description,
      CreateTime = c.CreateTime
    }).ToList();*/
    return _mapper.Map<List<CreateCategoryReadDto>>(_Categories);

    }//? Get Frist part start End...

    //? Get Seconde part start...!
    public CreateCategoryReadDto? GetCategoryById(Guid categoryId) //? Get/categories.... strat
    {
      var FoundCategory = _Categories.FirstOrDefault(c => c.CategoryId == categoryId);
     /*  if(FoundCategory == null){
      return null;
    }
   return new CreateCategoryReadDto
    {
      CategoryId = FoundCategory.CategoryId,
      Name = FoundCategory.Name,
      Description = FoundCategory.Description,
      CreateTime = FoundCategory.CreateTime
    };*/
    return FoundCategory == null ? null : _mapper.Map<CreateCategoryReadDto>(FoundCategory);
    

    }//? Get Seconde part start End...

    //? Post Create categories ...... start
    public CreateCategoryReadDto CreateCategoryPost(CreateCategoryDTO CategoryInData)
    {
      /*var newCategory = new Category(){
      CategoryId = Guid.NewGuid(),
      Name = CategoryInData.Name,
      Description = CategoryInData.Description,
      CreateTime = DateTime.UtcNow,
    };*/

    var newCategory = _mapper.Map<Category>(CategoryInData);
     newCategory.CategoryId = Guid.NewGuid();
     newCategory.Description = CategoryInData.Description;
    _Categories.Add(newCategory);

    /*return new CreateCategoryReadDto
    {
      CategoryId = newCategory.CategoryId,
      Name = newCategory.Name,
      Description = newCategory.Description,
      CreateTime = newCategory.CreateTime
    };*/
     return _mapper.Map<CreateCategoryReadDto>(newCategory);
    }//? Post Create categories ...... end

    //? Update Create categories ...... start
    public CreateCategoryReadDto? UpdateCategoryPost( Guid categoryId ,CreateCategoryUpdateDto CategoryInData)
    {
      var FoundCategory = _Categories.FirstOrDefault(category => category.CategoryId == categoryId);
      if(FoundCategory == null){
      return null;
    }
    _mapper.Map(CategoryInData, FoundCategory);
     /* FoundCategory.Name = CategoryInData.Name;
      FoundCategory.Description = CategoryInData.Description;
      return new CreateCategoryReadDto{
      CategoryId = FoundCategory.CategoryId,
      Name = FoundCategory.Name,
      Description = FoundCategory.Description,
      CreateTime = FoundCategory.CreateTime
    };
    */

       return _mapper.Map<CreateCategoryReadDto>(FoundCategory);
    }//? Update Create categories ...... end
    //? Delete In categories ...... Start
    public bool DeleteCategoryPost(Guid categoryId)
    {
      var FoundCategory = _Categories.FirstOrDefault(category => category.CategoryId == categoryId);
      if(FoundCategory == null){
      return false;
    }
      _Categories.Remove(FoundCategory);
      return true;

    }//? Delete In categories ...... end

    }
}