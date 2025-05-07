using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using dotnet_project_one.models;
using dotnet_project_one.DTOs;

namespace dotnet_project_one.Profiles
{
    public class CategoryIsProfile: Profile
    {
        public CategoryIsProfile(){
            CreateMap<Category, CreateCategoryReadDto>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateCategoryUpdateDto, Category>();
        }
    }
}