using System.ComponentModel;
using dotnet_project_one.Controllers;
using dotnet_project_one.Interfaces;
using dotnet_project_one.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

   var builder = WebApplication.CreateBuilder(args);

   //?Automapper Service.................!
   builder.Services.AddAutoMapper(typeof(Program));

   //? register Service.................!
   builder.Services.AddScoped<InterCategoryService, CategoryServices>();//?Interface and I

   builder.Services.AddControllers();
   //add service to the conntroller....................!
   builder.Services.Configure<ApiBehaviorOptions>(Options =>{
   Options.InvalidModelStateResponseFactory= Context =>
   {
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

   app.MapControllers();
   app.Run();


