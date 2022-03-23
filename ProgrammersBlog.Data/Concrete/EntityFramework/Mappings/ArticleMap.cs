using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article> //Hangi sınıfı mapping işlemine sokacaksak <> arasına o sınıfın ismini yazmalıyız.
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //HasKey : Bunun bir primary key alanı var mı diye sorguluyoruz.
            builder.HasKey(a => a.Id);//Burada olan primary key alanını vermiş olduk. Yani Id alanı primary key.
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); //Eklendikçe yeni bir değerin oluşmasını sağlıyor. Ve bir bir arttırıyor.
            builder.Property(a => a.Title).HasMaxLength(100); //title alanımızın en fazla 100 karakter olmasını sağlaalım.
            builder.Property(a => a.Title).IsRequired(true);//title alanımızın boş geçmemesini sağlayalım.
            builder.Property(a => a.Content).IsRequired();//bir makale asla boş bir şekilde paylaşılamaz anlamı taşır.
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");//alan nvarchar olarak oluşup maksimum değer alacaktır.
            builder.Property(a => a.Date).IsRequired();//kullanıcı makale için tarih seçmeli. Bu alan boş geçilmemeli.
            builder.Property(a => a.SeoAuthor).IsRequired();//makaleyi paylaşan seo bilgisi boş geçilmemeli.
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);//Yazarın ismi maksimum 50 karakter olabilir.
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();//Görüntülenme sayımız ve yorum sayımızın sayfada görüntülenmesi zorunludur.
            builder.Property(a => a.CommentCount).IsRequired();//Note değerimiz null geçilebilir. Dolayısıyla isrequired vermediğimizde böye bir zorunluluk olmayacaktır.
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a=>a.CategoryId);//Bir kategorinin birden fazla makalesi var...
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId); //Bire çok ilişki... Bir makale oluşurken hem yalnızca bir kategoriye hem de yalnızca bir kullanıcıya ihtiyaç duyacaktır.
            //Ancak bir kullanıcı ve bi kategori birden fazla makaleye sahip olabilecektir.
            builder.ToTable("Articles");//Tabloya dönüşürken hangi ismi almalı kısmını burada düzenleriz.
        }   
    }
}
