using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete
{
    //Somut bir sınıftır ve IArticleRepository'i implement eder.
    public class ArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        //DbContext verim bunu base e göndermemiz gerekiyor.
        public ArticleRepository(DbContext context) : base(context)
        {
        }
    }
}
