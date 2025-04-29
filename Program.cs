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
app.MapGet("/api/categories", ()=>{
  return Results.Ok(categories); // 200
});

//Post Method.........................!
app.MapPost("/api/categories", ([FromBody] Category CategoryInData) =>{
  // Console.WriteLine($"{CategoryInData}");
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
app.MapPut("/api/categories", ()=>{
  var FoundCategory = categories.FirstOrDefault(category => category.CategoryId ==Guid.Parse("ed7b8745-bb62-4e59-928f-6ed031d2ff1e"));

  if(FoundCategory == null){
    return Results.NotFound("This Category in Update is not found.......");
  }
  FoundCategory.Name = "smart category";
  FoundCategory.Description = "My Smary Phone";
  return Results.NoContent(); //204
});

//Delete Mathod...........................! 
app.MapDelete("/api/categories", ()=>{
  var FoundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("ed7b8745-bb62-4e59-928f-6ed031d2ff1e"));
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
  public String? Name{get; set;}
  public String? Description{get; set;}
  public DateTime CreateTime{get; set;}

}