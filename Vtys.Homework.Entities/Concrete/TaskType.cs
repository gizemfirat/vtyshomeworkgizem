using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class TaskType : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
