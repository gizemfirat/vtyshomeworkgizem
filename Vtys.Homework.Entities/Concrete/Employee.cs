using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Employee : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
