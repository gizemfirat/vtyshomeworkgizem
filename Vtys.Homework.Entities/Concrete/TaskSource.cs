using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class TaskSource : IEntity
    {
        public long Id { get; set; }

        public long TaskId { get; set; }

        public long SourceId { get; set; }
    }
}
