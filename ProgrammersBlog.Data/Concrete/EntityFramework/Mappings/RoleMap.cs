﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role> //Hangi sınıfı mapping işlemine sokacaksak <> arasına o sınıfın ismini yazmalıyız.
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            throw new NotImplementedException();
        }
    }
}
