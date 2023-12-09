using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.DataAccess
{
    public interface IQuery<T> where T : class, new()
    {
        T Run(object? args = null);
    }
}
