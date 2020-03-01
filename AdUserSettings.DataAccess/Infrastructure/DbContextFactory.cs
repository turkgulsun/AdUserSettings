using AdUserSettings.DataAccess.Concrete.EntityFramework;
using AdUserSettings.EntityFrameworkCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.DataAccess.Infrastructure
{
    public class DbContextFactory : IEntityFrameworkCoreContextFactory
    {
        private readonly AdUserSettingsContext _adUserSettingsContext;

        public DbContextFactory(AdUserSettingsContext adUserSettingsContext)
        {
            _adUserSettingsContext = adUserSettingsContext;
        }

        public DbContext GetDbContext()
        {
            return _adUserSettingsContext;
        }
    }
}
