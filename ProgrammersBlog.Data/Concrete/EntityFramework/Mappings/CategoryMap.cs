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
    public class CategoryMap : IEntityTypeConfiguration<Category> //Hangi sınıfı mapping işlemine sokacaksak <> arasına o sınıfın ismini yazmalıyız.
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.Id);//Id alanımızı primarykey yapalım.
            builder.Property(c => c.Id).ValueGeneratedOnAdd();//Bu alanın bir bir artmasını yani identity olmasını sağladık.
            builder.Property(c => c.Name).IsRequired();//Kategorinin ismini zorunlu yapalım.
            builder.Property(c => c.Name).HasMaxLength(70);//KAtegorinin adının uzunluğunu belirleyelim.
            builder.Property(c => c.Description).HasMaxLength(500);//Description kısmının uzunluğunu belirleyelim.
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categories");
        }
    }
}
