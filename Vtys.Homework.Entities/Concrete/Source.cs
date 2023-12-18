using System.ComponentModel.DataAnnotations;
using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Source : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public long SourceTypeId { get; set; }
    }
}
