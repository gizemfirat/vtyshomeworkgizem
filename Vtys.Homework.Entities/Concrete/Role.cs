using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Role : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
