using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project_one.models;
using Microsoft.AspNetCore.Mvc;

//---file code....................................!
namespace dotnet_project_one.Controllers
{
    [ApiController]
    [Route("api/categories")]
public class ControllersCategory:ControllerBase
{
private static List<Category> Categories = new List<Category>();

//Get:/api/categories = read categories..............................!
[HttpGet]
public IActionResult GetGategory([FromQuery] string searchValue="")
{
    if (!string.IsNullOrEmpty(searchValue))
    {
        var searchValueCategory = Categories
            .Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(searchValueCategory);
    }

    return Ok(Categories);
}//Get End


//Post:/api/categories = create Categories .........................// start....!
    [HttpPost]
 public IActionResult CreateCategory([FromBody] Category CategoryInData ){
    if(string.IsNullOrEmpty(CategoryInData.Name)){
    return BadRequest("category name is required and can not by empty");
}
    if(CategoryInData.Name.Length < 5){
    return BadRequest("Category name is must be atleast 5 characters...");
    }
    // if(char.IsUpper(CategoryInData.Name[0]))
    // {
    // return BadRequest("The first character is in upper case...");
    // }
var newCategory = new Category(){
    CategoryId = Guid.NewGuid(),
    Name = CategoryInData.Name,
    Description = CategoryInData.Description,
    CreateTime = DateTime.UtcNow,
};
    Categories.Add(newCategory);
    return Created($"/api/categories{newCategory.CategoryId}",newCategory);
    }       //End
    
//put:/api/categories{categoryId} = Update in Categories .........................// start....!
[HttpPut("{categoryId:guid}")]
  public IActionResult UpdateCategoryInId( Guid categoryId ,[FromBody] Category CategoryInData){
   if(CategoryInData == null){
  return BadRequest("Category with this id does not missing");
}
var FoundCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);

    if(FoundCategory == null){
    return NotFound("This Category in Update is not found.......");
    }

    if(!string.IsNullOrEmpty(CategoryInData.Name)){
     if(CategoryInData.Name.Length >= 2){
    FoundCategory.Name = CategoryInData.Name;
    }  else{
    return BadRequest("category Name is Must be atleast 2 characters long......");
    }
    }
    if(!string.IsNullOrWhiteSpace(CategoryInData.Description)){
     FoundCategory.Description = CategoryInData.Description;
    }
    return NoContent(); //204
    } //End

    //Delete:/api/categories = Delete in a Categories .........................// start....!
   [HttpDelete("{categoryId:guid}")]
public IActionResult DeleteCategory(Guid categoryId){
  var FoundCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);
    if(FoundCategory == null){
        return  NotFound("Category with this is does Not Exist..");
        }
        Categories.Remove(FoundCategory);
        return NoContent();
    } //end


} //ControlleresBase
} //Maine File -- controlllers  