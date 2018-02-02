using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Nop.Core.Infrastructure;
using Nop.Core.Configuration;

namespace Nop.Plugin.DiscountRules.BXGY
{
    public class DiscountRulesBXGYStartup : INopStartup
    {
        public int Order
        {
            get { return 10000; }
        }

        public void Configure(IApplicationBuilder application)
        {
            var nopConfig = EngineContext.Current.Resolve<NopConfig>();

            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Themes")),
                RequestPath = new PathString("/Themes"),
                OnPrepareResponse = ctx =>
                {
                    if (!string.IsNullOrEmpty(nopConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, nopConfig.StaticFilesCacheControl);
                }
            });
        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDiscountRulesBXGYThemes();

            services.AddScoped<AddProductToCartDetailsOverrideActionFilter>();
        }
    }
}
