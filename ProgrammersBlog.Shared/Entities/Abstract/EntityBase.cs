using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase // verdiğimiz temel değerlerin diğer sınıflarda değişikliğe uğramasını istiyosak başına abstract koyarız
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin"; //Herhangi bir nesne oluştuğunda bu kısımlar oto olarak admin olarak gelsin.
        public virtual string ModifiedByName { get; set; } = "Admin"; //String olarak tanımlamamızın sebebi blogumuzda kayıt ol kısmının olmamasıdır. Dolayısıyla kayıt olma olayı olmadığı için string olarak tutarız.
        public virtual string Note { get; set; }
    }

}
