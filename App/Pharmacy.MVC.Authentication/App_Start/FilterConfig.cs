﻿using System.Web;
using System.Web.Mvc;

namespace Pharmacy.MVC.Authentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}