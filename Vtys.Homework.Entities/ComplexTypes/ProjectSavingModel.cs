using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Entities.ComplexTypes
{
    public class ProjectSavingModel
    {
        public Project Project { get; set; }

        public long[] SourceIds { get; set; }
    }
}
