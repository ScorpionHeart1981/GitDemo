using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.DiscountRules.BXGY.Controllers
{
    public class DiscountBXGYProcessController : BasePluginController
    {
        public IActionResult SelectFreeProduct(int productId, int shoppingcarttypeId)
        {
            return View();
        }
    }
}
