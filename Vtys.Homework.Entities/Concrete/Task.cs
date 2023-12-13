using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Task : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public long TaskTypeId { get; set; }

        public long ProjectId { get; set; }

        public long LastStatusId { get; set; }
    }
}
