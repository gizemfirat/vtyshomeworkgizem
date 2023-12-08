using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class TaskStatusHistory : IEntity
    {
        public long Id { get; set; }
        public long StatusId { get; set; }

        public long TaskId { get; set; }
    }
}
