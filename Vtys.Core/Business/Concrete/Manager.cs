using Vtys.Core.Business.Abstract;

namespace Vtys.Core.Business.Concrete
{
    public class Manager: IService
    {
        protected Repository Repository;

        public Manager()
        {
            Repository = new Repository();
        }
    }
}
