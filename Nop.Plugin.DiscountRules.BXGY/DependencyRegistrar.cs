using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;

namespace Nop.Plugin.DiscountRules.BXGY
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 200; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<AddProductToCartDetailsOverrideActionFilter>().As<Microsoft.AspNetCore.Mvc.Filters.IFilterProvider>();
        }
    }
}
