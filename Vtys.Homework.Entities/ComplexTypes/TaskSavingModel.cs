using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Entities.ComplexTypes
{
    public class TaskSavingModel
    {
        public long ProjectId { get; set; }
        public Concrete.Task Task { get; set; }

        public long[] SourceIds { get; set; }
    }
}
