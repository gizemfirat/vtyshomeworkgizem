using Vtys.Core.Entities;

namespace Vtys.Homework.Entities.Concrete
{
    public class Employee : Source
    {
        public string Surname { get; set; }

        public long DepartmentId {  get; set; }
    }
}
