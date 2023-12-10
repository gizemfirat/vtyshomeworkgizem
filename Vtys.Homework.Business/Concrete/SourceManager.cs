using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class SourceManager : Manager, ISourceService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var sources = Repository.GetList<Source>();
            return new SuccessResult("", sources);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var source = Repository.Get<Source>(x => x.Id == id);
            return new SuccessResult("", source);
        }

        [ExceptionResultAspect]
        public IResult Save(Source source)
        {
            source = source.Id == 0
                ? Repository.Add(source)
                : Repository.Update(source);

            return new SuccessResult("", source);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var source = Repository.Get<Source>(x => x.Id == id);
            if (source != null)
            {
                Repository.Delete(source);
            }
            return new SuccessResult("Source deleted successfully!");
        }
    }
}
