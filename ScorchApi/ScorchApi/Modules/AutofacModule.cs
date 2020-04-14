using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using ScorchApi.Models;
using ScorchApi.Services;

namespace ScorchApi.Modules
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ////Services
            builder.RegisterType<AppService>().AsImplementedInterfaces();
            
            ////Other
            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<Mapper>().AsImplementedInterfaces();
        }
    }
}