namespace Vtys.Homework.Entities.ComplexTypes
{
    public class ProjectDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TaskDetail> Tasks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
