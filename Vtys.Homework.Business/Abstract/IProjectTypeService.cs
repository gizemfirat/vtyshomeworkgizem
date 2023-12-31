﻿using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface IProjectTypeService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(ProjectType projectType);
        IResult DeleteById(long id);
    }
}
