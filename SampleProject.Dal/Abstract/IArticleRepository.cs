﻿using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.Dal.Abstract
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
    }
}
