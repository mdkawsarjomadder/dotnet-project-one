using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace dotnet_project_one.DTOs
{
    public class CreateCategoryReadDto
    {
        public Guid CategoryId{get; set;}
        public String Name{get; set;}
        public String Description{get; set;} = string.Empty;
        public DateTime CreateTime{get; set;}   
    }
}