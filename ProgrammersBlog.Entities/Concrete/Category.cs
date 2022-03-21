using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    //Implementation
    public class Category:EntityBase, IEntity // bu classımıza data katmanından erişmek istediğimiz için public hale getirdik.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
