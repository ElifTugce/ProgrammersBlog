using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Contexts
{
    public class ProgrammersBlogContext:DbContext //DbContext olması için entityframework coredan gelen dbcontexten türemesi gerekiyor.
    {
        //Dbsetlerimizi hazırlayalım.
        //Aşağıda verdiklerimiz kod tabanında erişip kullandığımız isimlerdir. Yani veritabanımıza giderken bu isimlerle gitmeyecektir. Bunları fluent api iğle ayarlayacağız.

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        //SQLServer connection string vermemiz gerekiyor.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bu kısım kurduğumuz nugget sayesinde geliyor. Eğer farklı veritabanı yönetim sistemi kullanmak istersek örn mysql gibi... onun nuggetini kurarak devam edebiliriz.
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-HNE43R2; Database = ProgrammersBlog; Trusted_Connection = True; Connect Timeout = 30; MultipleActiveResultSets = True;");
        }
    }
}
