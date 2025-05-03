using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace dotnet_project_one.DTOs
{
    public class CreateCategoryUpdateDto
    {
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Category Name is Must Be Between 4 and 100 characters...")]
        public String Name{get; set;} = string.Empty;
        [StringLength(500, ErrorMessage ="Category description Cannot is exceed 500 characters...!")]
        public String Description{get; set;} = string.Empty;
    }
}