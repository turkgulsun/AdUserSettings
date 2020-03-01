using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.DataAccess.Concrete.EntityFramework
{
    public class AdUserSettingsContext:DbContext
    {
        public AdUserSettingsContext(DbContextOptions options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<ClassTypeConfiguration>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdUserSettingsContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
