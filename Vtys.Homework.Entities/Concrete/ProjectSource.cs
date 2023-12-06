using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class ProjectSource : IEntity
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public long SourceId { get; set; }
    }
}
