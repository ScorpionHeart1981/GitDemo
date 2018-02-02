using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.DiscountRules.BXGY.Models
{
    public class RequirementModel
    {
        public RequirementModel()
        {
        }

        public int DiscountId { get; set; }

        public int RequirementId { get; set; }

        public int BuyNumber { get; set; }

        public int GetNumber { get; set; }
    }
}