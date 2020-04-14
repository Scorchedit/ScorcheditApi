using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using ScorchApi.Models;

[assembly: OwinStartup(typeof(ScorchApi.Startup))]

namespace ScorchApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
