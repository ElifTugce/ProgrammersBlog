using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IArticleRepository:IEntityRepository<Article> //Article ile çalışmak istiyoruz.
        //Yani hepsi için tek tek tanımlamak yerine Generic bir şekilde bir kere yazdık ve her yerde kullanmaya başladık.
    {
    }
}
