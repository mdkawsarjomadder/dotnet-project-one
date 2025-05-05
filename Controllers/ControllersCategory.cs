using System;
using System.Buffers;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project_one.DTOs;
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
    private CategoryServices _categoryService;

    public ControllersCategory(CategoryServices categoryServices)
    {
        _categoryService = categoryServices;
    }
    //? Depandency..................end
// private static List<Category> Categories = new List<Category>();//tule nea hoicce

//Get:/api/categories = read categories..............................!
    [HttpGet]
    public IActionResult GetGategory([FromQuery] string searchValue="")
    {
    /* if (!string.IsNullOrEmpty(searchValue))
    {
    var searchValueCategory = Categories
    .Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
    .ToList();
    return Ok(searchValueCategory);
    }*/
    var CategoryToList = _categoryService.ServicesInGetCategories(); //*ServicesInGetCategories
    return Ok(ApiResponse<List<CreateCategoryReadDto>>.SuccessRespons (CategoryToList,200,"Category Returen Successfuly..."));
}//Get End

//Get:/api/categories/{categoryId} = read categories in categoryById..............................!
//     [HttpGet("{categoryId:guid}")]
//     public IActionResult GetGategoryById(Guid categoryId)
//     {
//         var FoundCategory = Categories.FirstOrDefault(c => c.CategoryId == categoryId);
//          if(FoundCategory == null){
//           return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category is not Found with this Id is missing"},400, "Validation is Failed.!"));
//         }
//     /* if (!string.IsNullOrEmpty(searchValue))
//     {
//     var searchValueCategory = Categories
//     .Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
//     .ToList();
//     return Ok(searchValueCategory);
//     }*/
//     var CategoryReadById =  new CreateCategoryReadDto{
//         CategoryId = FoundCategory.CategoryId,
//         Name = FoundCategory.Name,
//         Description = FoundCategory.Description,
//         CreateTime = FoundCategory.CreateTime
//         };

//     return Ok(ApiResponse<CreateCategoryReadDto>.SuccessRespons (CategoryReadById,200,"Category Returen is Successfuly..."));
// }//Get End


//Post:/api/categories = create Categories .........................// start....!
    // [HttpPost]
    // public IActionResult CreateCategory([FromBody] CreateCategoryDTO  CategoryInData )
    // {
    // /* if(string.IsNullOrEmpty(CategoryInData.Name)){
    // return BadRequest("category name is required and can not by empty");
    // }
    // if(CategoryInData.Name.Length < 5){
    // return BadRequest("Category name is must be atleast 5 characters...");
    // }*/
    // /*//------------annotations date......................
    // if(!ModelState.IsValid)
    // {
    // var errors = ModelState
    //     .Where(e =>e.Value.Errors.Count>0)
    //     .Select(e => new{
    //     Filed = e.Key,
    //     Message =e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
    //     }).ToList();
    // var errorString = string.Join(";",errors.Select(e =>$"{e.Filed} : {string.Join(",",e.Message)}"));  
    //     return BadRequest(errorString);
    // }*/

    // var newCategory = new Category(){
    //     CategoryId = Guid.NewGuid(),
    //     Name = CategoryInData.Name,
    //     Description = CategoryInData.Description,
    //     CreateTime = DateTime.UtcNow,
    // };
    // Categories.Add(newCategory);

    // var CategoryReadDto = new CreateCategoryReadDto{
    //     CategoryId = newCategory.CategoryId,
    //     Name = newCategory.Name,
    //     Description = newCategory.Description,
    //     CreateTime = newCategory.CreateTime
    // };

    // return Created(nameof(GetGategoryById),
    
    // ApiResponse<CreateCategoryReadDto>.SuccessRespons (CategoryReadDto,201,"Category Create in Successfuly..."));
    // }       //End
    
//put:/api/categories{categoryId} = Update in Categories .........................// start....!
    // [HttpPut("{categoryId:guid}")]
    // public IActionResult UpdateCategoryInId( Guid categoryId ,[FromBody] CreateCategoryUpdateDto CategoryInData)
    // {
    //     // if(CategoryInData == null){
    //     //     return BadRequest("Category with this id does not missing");
    //     //     }
    //     var FoundCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);
    //     if(FoundCategory == null){
    //       return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category is not Found with this Id is missing"},400, "Validation is Failed.!"));
    //     }
    //     FoundCategory.Name = CategoryInData.Name;
    //     FoundCategory.Description = CategoryInData.Description;

    //     return Ok(ApiResponse<object>.SuccessRespons (null,204,"Category Update in Successfuly...")); //204
    // }

       /* if(!string.IsNullOrEmpty(CategoryInData.Name)){
        if(CategoryInData.Name.Length >= 2){
        FoundCategory.Name = CategoryInData.Name;
        }  else{
        return BadRequest("category Name is Must be atleast 2 characters long......");
        }
        }
        if(!string.IsNullOrWhiteSpace(CategoryInData.Description)){
        FoundCategory.Description = CategoryInData.Description;
        }
    return Ok(ApiResponse<object>.SuccessRespons (null,204,"Category Update in Successfuly...")); //204
    } //End
*/
    //Delete:/api/categories = Delete in a Categories .........................// start....!
//     [HttpDelete("{categoryId:guid}")]
//     public IActionResult DeleteCategory(Guid categoryId){
//     var FoundCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);
//         if(FoundCategory == null){
//             return NotFound(ApiResponse<object>.ErrorsRespons(new List<string> {"Category with this Id does not exist..!"},400,"Validation is Failed.!"));

//         }
//     Categories.Remove(FoundCategory);
//     return Ok(ApiResponse<object>.SuccessRespons(null,204,"Category Delete In Successful...!"));
//     } //end


// } //ControlleresBase
} 
}//Maine File -- controlllers  