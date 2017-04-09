using AlimexDAL.Model;
using AlimexDAL.Repository;
using AlimexIdentity.Controller;
using AlimexService;
using Autofac;
using System;

namespace AlimexDAL
{
    public class RegisterComponent : Module
    {
        #region Protected Methods

        protected override void Load(ContainerBuilder builder)
        {           
        
            builder.RegisterGeneric(typeof(Repository<>))
               .As(typeof(IRepository<>))
               .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
             .As<IUserService>()
             .InstancePerLifetimeScope();            
        }

        #endregion Protected Methods
    }
}
