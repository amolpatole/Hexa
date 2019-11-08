using Autofac;
using CoreServicesDemoMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreServicesDemoMVC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
        }
    }
}
