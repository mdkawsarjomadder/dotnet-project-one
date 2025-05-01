using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


//add service to the conntroller....................!
builder.Services.AddControllers();

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


