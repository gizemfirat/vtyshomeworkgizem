using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Department : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
