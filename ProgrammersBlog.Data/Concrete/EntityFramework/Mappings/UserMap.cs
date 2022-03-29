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
    public class UserMap : IEntityTypeConfiguration<User>//Hangi sınıfı mapping işlemine sokacaksak <> arasına o sınıfın ismini yazmalıyız.
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);
            builder.Property(u=>u.Id).ValueGeneratedOnAdd();
            builder.Property(u=>u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u=>u.Email).IsUnique();//Email uniqe olmalı...
            //Aynı işlemleri kullanıcı adı için de yapalım...
            builder.Property(u=>u.Username).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(20);
            builder.HasIndex(u=>u.Username).IsUnique();
            //Şifre alanımızı belirleyelim.
            builder.Property(u=>u.PasswordHash).IsRequired();
            builder.Property(u=>u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.Description).HasMaxLength(500);//Kullanıcının kendisini anlattığı kısım burasıdır.
            builder.Property(u=>u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u=>u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u=>u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            //Bir role ihtiyacımız var aynı zamanda bir rolde birden fazla kullanıcıya sahip olabiliriz.
            builder.HasOne<Role>(u=>u.Role).WithMany(r=>r.Users).HasForeignKey(u=>u.RoleId);
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500);
            builder.ToTable("Users");

        }
    }
}
