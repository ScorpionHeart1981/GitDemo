using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http;

namespace Nop.Plugin.DiscountRules.BXGY
{
    public class AddProductToCartDetailsOverrideActionFilter : ActionFilterAttribute, IFilterProvider
    {
        private int i = 0;
        private string discountRuleCacheKey = "NLTD.BXGY";

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var a = filterContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var formCollection = (FormCollection)context.HttpContext.Request.Form;
            var actionArguments = context.ActionArguments;
            int productid = (context.ActionArguments.ContainsKey("productid")) ? (int)context.ActionArguments["productid"] : 0;
            int shoppingcarttypeid = (context.ActionArguments.ContainsKey("shoppingcarttypeid")) ? (int)context.ActionArguments["shoppingcarttypeid"] : 0;
            //RedirectToRouteResult rt = new RedirectToRouteResult("Plugin.DiscountRules.BXGY.SelectFreeProduct", new { productId = productid, shoppingcarttypeId = shoppingcarttypeid });
            //context.Result = rt;

            UrlHelper urlHelper = new UrlHelper(context);
            string redirectUrl = urlHelper.RouteUrl("Plugin.DiscountRules.BXGY.SelectFreeProduct", new { productId = productid, shoppingcarttypeId = shoppingcarttypeid });
            JsonResult json = new JsonResult(new { redirect = redirectUrl });
            context.Result = json;

            base.OnActionExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var a = context;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var a = context;
        }

        public void OnProvidersExecuting(FilterProviderContext context)
        {
            var a = context.ActionContext.ActionDescriptor;

            if (context.ActionContext.RouteData.Values["action"].ToString().ToLower() == "addproducttocart_details"
                && context.ActionContext.RouteData.Values["controller"].ToString().ToLower() == "shoppingcart")
            {
                FilterDescriptor filterDescriptor = new FilterDescriptor(this, FilterScope.Action);
                filterDescriptor.Order = 0;
                context.Results.Add(new FilterItem(filterDescriptor, this));
            }
        }

        public void OnProvidersExecuted(FilterProviderContext context)
        {
            var a = context.ActionContext.ActionDescriptor;
        }
    }
}
