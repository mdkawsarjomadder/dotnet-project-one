using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project_one.DTOs
{
    public class CreateCategoryDTO
    {
    public String Name{get; set;}
    public String Description{get; set;} = string.Empty;
    }
}