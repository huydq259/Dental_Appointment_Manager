using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Appointment_Manager.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Trang_Chu()
        {
            return View();
        }
    }
}