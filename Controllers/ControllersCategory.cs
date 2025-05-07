using System;
using System.Buffers;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project_one.DTOs;
using dotnet_project_one.Interfaces;
using dotnet_project_one.models;
using dotnet_project_one.Services;
using Microsoft.AspNetCore.Mvc;

//---file code....................................!
namespace dotnet_project_one.Controllers
{
    [ApiController]
    [Route("v1/api/categories")]
public class ControllersCategory:ControllerBase
{
    //? Depandency..................start
    private InterCategoryService _categoryService;

    public ControllersCategory(InterCategoryService categoryServices)
    {
        _categoryService = categoryServices;
    }
    //? Depandency..................end
//Get:/api/categories = read categories..............................!
    [HttpGet]
    public IActionResult GetGategory([FromQuery] string searchValue="")
    {
    var CategoryToList = _categoryService.ServicesInGetCategories(); //*ServicesInGetCategories
    return Ok(ApiResponse<List<CreateCategoryReadDto>>.SuccessRespons (CategoryToList,200,"Category Returen Successfuly..."));
}//Get End

//?Get:/api/categories/{categoryId} = read categories in categoryById.....start!.........................!
    [HttpGet("{categoryId:guid}")]
    public IActionResult GetGategoryById(Guid categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);
         if(category == null){
          return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category is not Found with this Id is missing"},400, "Validation is Failed.!"));
        }
    return Ok(ApiResponse<CreateCategoryReadDto>.SuccessRespons (category,200,"Category Returen is Successfuly..."));
}//?Get End
//?Post:/api/categories = create Categories ...Strat......................// start....!
    [HttpPost]
    public IActionResult CreateCategory([FromBody] CreateCategoryDTO  CategoryInData )
    {
    var CategoryReadDto = _categoryService.CreateCategoryPost(CategoryInData);
    return Created(nameof(GetGategoryById),
    
    ApiResponse<CreateCategoryReadDto>.SuccessRespons (CategoryReadDto,201,"Category Create in Successfuly..."));
    }  //?End
    
//?put:/api/categories{categoryId} = Update in Categories .........................// start....!
    [HttpPut("{categoryId:guid}")]
    public IActionResult UpdateCategoryInId( Guid categoryId ,[FromBody] CreateCategoryUpdateDto CategoryInData)
    {
        var UpdateCategory = _categoryService.UpdateCategoryPost(categoryId, CategoryInData);
        if(UpdateCategory == null){
          return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category is not Found with this Id is missing"},400, "Validation is Failed.!"));
        }
        UpdateCategory.Name = CategoryInData.Name;
        UpdateCategory.Description = CategoryInData.Description;

        return Ok(ApiResponse<CreateCategoryReadDto>.SuccessRespons (UpdateCategory,200,"Category Update in Successfuly...")); //204
    }

    //?Delete:/api/categories = Delete in a Categories .........................// start....!
    [HttpDelete("{categoryId:guid}")]
    public IActionResult DeleteCategory(Guid categoryId){
        
    var FoundCategory = _categoryService.DeleteCategoryPost(categoryId);
        if(!FoundCategory){
            return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category with this Id does not exist..!"},400,"Validation is Failed.!"));

        }
    return Ok(ApiResponse<object>.SuccessRespons(null,204,"Category Delete In Successful...!"));
    } //?end


} //ControlleresBase
} //Maine File -- controlllers  