using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class ProjectStatusHistory : IEntity
    {
        public long Id { get; set; }
        public long StatusId { get; set; }

        public long ProjectId { get; set; }

        public DateTime InsertedDate { get; set; }
    }
}
