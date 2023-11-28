using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message = "", object? data = null) : base(true, message, data)
        {
        }
    }
}
