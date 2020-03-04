using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public static List<Customer> customerList = new List<Customer>()
        {
            new Customer() { Name = "Sean", Id = 04162000 },
            new Customer() { Name = "Erin", Id = 02222000 }
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomerListViewModel() { Customers = customerList };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (id >= 0 && id < customerList.Count)
            {
                return View(customerList[id]);
            }   else
            {
                return Redirect("Customers");
            }
            
        }
    }
}