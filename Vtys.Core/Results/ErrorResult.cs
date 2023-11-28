using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.Results
{
    public class ErrorResult : Result
    {
        public Exception? Exception { get; }

        public ErrorResult(string message = "") : base(false, message)
        {
        }

        public ErrorResult(string message, Exception exception) : base(false, message)
        {
            Exception = exception;
        }

        public ErrorResult(string message, object data) : base(false, message, data)
        {
        }

        public ErrorResult(string message, Exception exception, object data) : base(false, message, data)
        {
            Exception = exception;
        }
    }
}
