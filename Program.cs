using System.ComponentModel;

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
app.MapPost("/api/categories", () =>{
 return Results.Created();
});

//Put Mathod...........................! 
app.MapPut("/api/categories", ()=>{
  return Results.NoContent(); //204
});

//Delete Mathod...........................! 
app.MapDelete("/api/categories", ()=>{
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