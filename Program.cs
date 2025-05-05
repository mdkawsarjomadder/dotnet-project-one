using System.ComponentModel;
using dotnet_project_one.Controllers;
using dotnet_project_one.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

   var builder = WebApplication.CreateBuilder(args);

   //? register Service.................!
   builder.Services.AddSingleton<CategoryServices>();

   builder.Services.AddControllers();
   //add service to the conntroller....................!
   builder.Services.Configure<ApiBehaviorOptions>(Options =>{
   Options.InvalidModelStateResponseFactory= Context =>
   {
  /* // var errors = Context.ModelState
   //    .Where(e =>e.Value != null && e.Value.Errors.Count>0)
   //    .Select(e => new{
   //    Filed = e.Key,
   //    Errors =e.Value != null ? e.Value.Errors.Select(x => x.ErrorMessage).ToArray() : new string[0]
   //    }).ToList();

     //var errorString = string.Join(";",errors.Select(e =>$"{e.Filed} : {string.Join(",",e.Errors)}"));  
*/

   var errors = Context.ModelState
      .Where(e =>e.Value != null && e.Value.Errors.Count>0)
      .SelectMany(e => e.Value?.Errors != null ? e.Value.Errors.Select(x =>x.ErrorMessage):new List<String>()).ToList();
   return new BadRequestObjectResult(ApiResponse<object>.ErrorsRespons(errors,400,"Validation Failed!"));
   };

   });
   builder.Services.AddEndpointsApiExplorer();
   builder.Services.AddSwaggerGen();


   var app = builder.Build();

   if(app.Environment.IsDevelopment())
      {
      app.UseSwagger();
      app.UseSwaggerUI();
      }

   app.UseHttpsRedirection();



   app.MapGet( "/", () =>"My First Project");
   /*
   //Get Mathod.............................! 
   // app.MapGet("/api/categories", ([FromBody] string searchValue )=>{});

   //Post Method.........................!
   // app.MapPost("/api/categories", ([FromBody] Category CategoryInData) =>{});

   //Put Mathod...........................! 
   // app.MapPut("/api/categories/{categoryId:guid}",( Guid categoryId ,[FromBody] Category CategoryInData)=>{});

   //Delete Mathod...........................! 
   //app.MapDelete("/api/categories/{categoryId:guid}", (Guid categoryId)=>{});

   */

   app.MapControllers();
   app.Run();


