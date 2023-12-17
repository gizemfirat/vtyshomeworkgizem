namespace Vtys.Homework.Entities.Concrete
{
    public class Machine : Source
    {
        public int SerialNumber { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
