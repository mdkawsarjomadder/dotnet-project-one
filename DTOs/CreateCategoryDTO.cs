using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project_one.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage="Category Name is Required.....!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Category must be name is betweek 4 and 100 character")]
        public String Name{get; set;} = string.Empty;
        [StringLength(500, ErrorMessage = "Category description  cannot  exceed  500 Charecter.")]
        public String Description{get; set;} = string.Empty;
    }
}