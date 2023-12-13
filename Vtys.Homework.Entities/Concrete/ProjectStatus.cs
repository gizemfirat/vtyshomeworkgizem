using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class ProjectStatus : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
    }
}
