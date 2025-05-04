using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_project_one.Controllers
{
    public class ApiResponse<T>
    {
            public ApiResponse(bool success, string message, int statusCode, DateTime timesamp) 
        {
              this.Success = success;
                  this.Message = message;
                  this.StatusCode = statusCode;
                  this.TimeStamp = timesamp;
               
        }
                public bool Success{get; set;}
        public string Message{get; set;} =string.Empty;
        public T? Data{set; get;}
        public List<String>? Errors{set; get;}
        public int StatusCode{get; set;}
        public DateTime TimeStamp{get; set;}

        // constructor for successful response..........!
      private  ApiResponse(bool success,string message,T? data, List<String>? errors, int statusCode){
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
        }
        // static method for creating  a successful respons..............!
        public static ApiResponse<T> SuccessRespons(T? data, int statusCode, string message=""){
            return new ApiResponse<T>(true,message,data,null,statusCode);
        }
        // static method for creating  an Errors respons..................!
        public static ApiResponse<T> ErrorsRespons(List<String> errors, int statusCode, string message=""){
            return new ApiResponse<T>(false,message,default(T),errors,statusCode);
        }
        // constructor for successful respons...........!
    }
}