using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;

namespace UDW.Controllers
{
    public class ModuleController : Controller
    {
        ///////////////////////////////////////////////////////////////////////////
        MenusDAO menusDAO = new MenusDAO();

        ///////////////////////////////////////////////////////////////////////////
        // GET: Mainmenu
        public ActionResult MainMenu()
        {
            List<Menus> list = menusDAO.getListByParentId(0,"MainMenu");
            return View("MainMenu",list);
        }
        ///////////////////////////////////////////////////////////////////////////
        // GET: MainmenuSub
        public ActionResult MainMenuSub(int id)
        {
            List<Menus> list = menusDAO.getListByParentId(id, "MainMenu");
            if (list.Count == 0)//menu khong co cap con
            {
                return View("MainMenuSub_0", list);
            }
            else//menu co cap con
            {
                return View("MainMenuSub_1", list);
            }
            
        }
    }
}