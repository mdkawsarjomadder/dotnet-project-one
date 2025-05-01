using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project_one.models
{
   public class Category
{
public Guid CategoryId{get; set;}
public String Name{get; set;}
public String Description{get; set;} = string.Empty;
public DateTime CreateTime{get; set;}

}
}