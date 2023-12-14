using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Entities.ComplexTypes
{
    public class TaskDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SourceDetail> Sources { get; set; }
    }
}
