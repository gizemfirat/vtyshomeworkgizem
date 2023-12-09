﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Project : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly FinishDate { get; set; }
    }
}