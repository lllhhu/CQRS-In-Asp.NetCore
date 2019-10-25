using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service
{
    public class Result
    {
        public Result(int code=200,string message= "successful")
        {
            this.Code = code;
            this.Message = message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
    }

}
