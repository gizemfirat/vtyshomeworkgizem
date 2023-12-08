using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
