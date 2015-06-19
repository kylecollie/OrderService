using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderApp.Controllers
{
    public class OrderManagementController : Controller
    {
        // GET: OrderManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}