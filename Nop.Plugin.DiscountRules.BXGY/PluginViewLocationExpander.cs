using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Themes;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.DiscountRules.BXGY
{
    public class PluginViewLocationExpander : IViewLocationExpander
    {
        private const string PLUGIN_KEY = "discountrules.bxgy";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var themeContext = (IThemeContext)context.ActionContext.HttpContext.RequestServices.GetService(typeof(IThemeContext));
            context.Values[PLUGIN_KEY] = themeContext.WorkingThemeName;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.TryGetValue(PLUGIN_KEY, out string theme))
            {
                viewLocations = new[] {
                        $"/Plugins/DiscountRules.BXGY/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/DiscountRules.BXGY/Views/Shared/{{1}}/{{0}}.cshtml",
                        $"/Plugins/DiscountRules.BXGY/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/DiscountRules.BXGY/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                    }
                    .Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}
