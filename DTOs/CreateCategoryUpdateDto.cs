using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_project_one.DTOs
{
    public class CreateCategoryUpdateDto
    {
        public String Name{get; set;} = default!;
        public String Description{get; set;} = string.Empty;
    }
}