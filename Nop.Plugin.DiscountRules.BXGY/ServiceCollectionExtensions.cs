using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Nop.Plugin.DiscountRules.BXGY
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDiscountRulesBXGYThemes(this IServiceCollection services)
        {
            //themes support
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new PluginViewLocationExpander());
            });
        }
    }
}
