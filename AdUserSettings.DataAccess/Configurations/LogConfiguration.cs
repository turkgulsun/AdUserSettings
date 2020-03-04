using AdUserSettings.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.DataAccess.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.IPAddress).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnType("datetime").IsRequired(); ;
        }
    }
}
