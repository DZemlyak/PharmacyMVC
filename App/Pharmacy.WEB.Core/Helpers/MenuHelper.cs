using System;
using System.Linq;
using System.Web.Mvc;

namespace Pharmacy.WEB.Core.Helpers
{
    public static class MenuHelper
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            var currentAction = (string) html.ViewContext.RouteData.Values["action"];
            var currentController = (string) html.ViewContext.RouteData.Values["controller"];
            
            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller.Split(';').Contains(currentController) && action.Split(';').Contains(currentAction) ?
                cssClass : String.Empty;

        }
    }
}