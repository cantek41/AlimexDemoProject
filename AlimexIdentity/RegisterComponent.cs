
using AlimexIdentity.Controller;
using Autofac;
using System;

namespace AlimexIdentity
{
    public class RegisterComponent : Module
    {
        #region Protected Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityLogin>().AsSelf();
        }

        #endregion Protected Methods
    }
}
