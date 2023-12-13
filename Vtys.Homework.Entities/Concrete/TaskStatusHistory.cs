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
