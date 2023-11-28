using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.Results
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public object? Data { get; }

        public Result(bool isSuccess, string message, object? data = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
