using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();



List<Category> categories = new List<Category>();

app.MapGet( "/", () =>"My First Project");
//Get Mathod.............................! 
app.MapGet("/api/categories", ( [FromQuery]string searchValue="")=>{
Console.WriteLine($"{searchValue}");
if(!String.IsNullOrEmpty(searchValue)){
  var searchValueCategory = categories.Where(c =>c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
    return Results.Ok(searchValueCategory);
}

return Results.Ok(categories); // 200
});

//Post Method.........................!
app.MapPost("/api/categories", ([FromBody] Category CategoryInData) =>{

if(string.IsNullOrEmpty(CategoryInData.Name)){
  return Results.BadRequest("category name is required and can not by empty");
}
if(CategoryInData.Name.Length > 5){
  return Results.BadRequest("Category name is must be atleast 5 characters...");
}
if(char.IsUpper(CategoryInData.Name[0]))
{
  return Results.BadRequest("The first character is in upper case...");
}
var newCategory = new Category(){
    CategoryId = Guid.NewGuid(),
    Name = CategoryInData.Name,
    Description = CategoryInData.Description,
    CreateTime = DateTime.UtcNow,
};
categories.Add(newCategory);
return Results.Created($"/api/categories{newCategory.CategoryId}",newCategory);

});

//Put Mathod...........................! 
app.MapPut("/api/categories/{categoryId:guid}",( Guid categoryId ,[FromBody] Category CategoryInData)=>{
if(CategoryInData == null){
  return Results.BadRequest("Category with this id does not missing");
}
var FoundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

if(FoundCategory == null){
  return Results.NotFound("This Category in Update is not found.......");
}

if(!string.IsNullOrEmpty(CategoryInData.Name)){
  if(CategoryInData.Name.Length >= 2){
    FoundCategory.Name = CategoryInData.Name;
  } else{
    return Results.BadRequest("category Name is Must be atleast 2 characters long......");
  }
}
if(!string.IsNullOrWhiteSpace(CategoryInData.Description)){
  FoundCategory.Description = CategoryInData.Description;
}
return Results.NoContent(); //204
});

//Delete Mathod...........................! 
app.MapDelete("/api/categories/{categoryId:guid}", (Guid categoryId)=>{
var FoundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
if(FoundCategory == null){
  return  Results.NotFound("Category with this is does Not Exist..");
}
  categories.Remove(FoundCategory);
return Results.NoContent();//204
});




app.Run();


public record Category
{
public Guid CategoryId{get; set;}
public String Name{get; set;}
public String Description{get; set;} = string.Empty;
public DateTime CreateTime{get; set;}

}