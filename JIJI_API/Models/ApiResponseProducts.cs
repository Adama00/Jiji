﻿namespace JIJI_API.Models
{
    public class ApiResponseProducts<T>
    {
        public string Code {  get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
       
    }
}
