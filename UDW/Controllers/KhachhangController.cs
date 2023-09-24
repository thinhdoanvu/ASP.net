using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UDW.Library;

namespace UDW.Controllers
{
    public class KhachhangController : Controller
    {
        //////////////////////////////////////////////////////////////////////////
        // GET: Khachhang DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection field)
        {
            String username = field["username"];
            String password = XString.ToMD5(field["password"]);
            
            return View("DangNhap");
        }

        //////////////////////////////////////////////////////////////////////////
        // GET: Khachhang DangKy
        public ActionResult DangKy()
        {
            return View();
        }
    }
}