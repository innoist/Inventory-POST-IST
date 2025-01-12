﻿using System.Data.Entity;
using TMD.Interfaces.Repository;
using TMD.Repository.BaseRepository;
using TMD.Repository.Repositories;
using Microsoft.Practices.Unity;
namespace TMD.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            
            unityContainer.RegisterType<IAspNetUserRepository, AspNetUserRepository>();
            unityContainer.RegisterType<IStagingEbayBatchImportsRepository, StagingEbayBatchImportsRepository>();
            unityContainer.RegisterType<IStagingEbayItemRepository, StagingEbayItemRepository>();
            unityContainer.RegisterType<IConfigurationRepository, ConfigurationRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
        }
    }
}
