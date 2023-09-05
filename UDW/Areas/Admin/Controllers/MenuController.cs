using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
using UDW.Library;

namespace UDW.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        //Goi 4 lop DAO can thuc thi
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        TopicsDAO topicsDAO = new TopicsDAO();
        PostsDAO postsDAO = new PostsDAO();
        MenusDAO menusDAO = new MenusDAO();
        SuppliersDAO suppliersDAO = new SuppliersDAO();//neu thich thi lam

        /////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Menu
        public ActionResult Index()
        {
            ViewBag.CatList = categoriesDAO.getList("Index");//select * from Categories voi Status !=0
            ViewBag.TopList = topicsDAO.getList("Index");//select * from Topics voi Status !=0
            ViewBag.PosList = postsDAO.getList("Index");//select * from Posts voi Status !=0
            List<Menus> menu = menusDAO.getList("Index");//select * from Menus voi Status !=0
            return View("Index", menu);//truyen menu duoi dang model
        }

        // POST: Admin/Menu: Select * from
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //-------------------------Category------------------------//
            //Xu ly cho nút ThemCategory ben Index
            if (!string.IsNullOrEmpty(form["ThemCategory"]))//nut ThemCategory duoc nhan
            {
                if (!string.IsNullOrEmpty(form["nameCategory"]))//check box được nhấn
                {
                    var listitem = form["nameCategory"];
                    //chuyen danh sach thanh dang mang: vi du 1,2,3,...
                    var listarr = listitem.Split(',');//cat theo dau ,
                    foreach (var row in listarr)//row = id cua các mau tin
                    {
                        int id = int.Parse(row);//ep kieu int
                        //lay 1 ban ghi
                        Categories categories = categoriesDAO.getRow(id);
                        //tao ra menu
                        Menus menu = new Menus();
                        menu.Name = categories.Name;
                        menu.Link = categories.Slug;
                        menu.TableId = categories.Id;
                        menu.TypeMenu = "category";
                        menu.Position = form["Position"];
                        menu.ParentId = 0;
                        menu.Order = 0;
                        menu.CreateBy = Convert.ToInt32(Session["UserId"].ToString());
                        menu.CreateAt = DateTime.Now;
                        menu.Status = 2;//chưa xuất bản
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm menu danh mục thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục loại sản phẩm");
                }
            }

            //-------------------------Topic------------------------//
            //Xu ly cho nút ThemTopic ben Index
            if (!string.IsNullOrEmpty(form["ThemTopic"]))//nut ThemCategory duoc nhan
            {
                if (!string.IsNullOrEmpty(form["nameTopic"]))//check box được nhấn
                {
                    var listitem = form["nameTopic"];
                    //chuyen danh sach thanh dang mang: vi du 1,2,3,...
                    var listarr = listitem.Split(',');//cat theo dau ,
                    foreach (var row in listarr)//row = id cua các mau tin
                    {
                        int id = int.Parse(row);//ep kieu int
                                                //lay 1 ban ghi
                        Topics topics = topicsDAO.getRow(id);
                        //tao ra menu
                        Menus menu = new Menus();
                        menu.Name = topics.Name;
                        menu.Link = topics.Slug;
                        menu.TableId = topics.Id;
                        menu.TypeMenu = "topic";
                        menu.Position = form["Position"];
                        menu.ParentId = 0;
                        menu.Order = 0;
                        menu.CreateBy = Convert.ToInt32(Session["UserId"].ToString());
                        menu.CreateAt = DateTime.Now;
                        menu.Status = 2;//chưa xuất bản
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm menu chủ đề bài viết thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục chủ đề bài viết");
                }
            }

            //-------------------------Page------------------------//
            //Xử lý cho nut Thempage ben Index
            if (!string.IsNullOrEmpty(form["ThemPage"]))
            {
                if (!string.IsNullOrEmpty(form["namePage"]))//check box được nhấn tu phia Index
                {
                    var listitem = form["namePage"];
                    //chuyen danh sach thanh dang mang: vi du 1,2,3,...
                    var listarr = listitem.Split(',');//cat theo dau ,
                    foreach (var row in listarr)//row = id cua các mau tin
                    {
                        int id = int.Parse(row);//ep kieu int
                        Posts post = postsDAO.getRow(id);
                        //tao ra menu
                        Menus menu = new Menus();
                        menu.Name = post.Title;
                        menu.Link = post.Slug;
                        menu.TableId = post.Id;
                        menu.TypeMenu = "page";
                        menu.Position = form["Position"];
                        menu.ParentId = 0;
                        menu.Order = 0;
                        menu.CreateBy = Convert.ToInt32(Session["UserId"].ToString());
                        menu.CreateAt = DateTime.Now;
                        menu.Status = 2;//chưa xuất bản
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm menu bài viết thành công");
                }
                else//check box chưa được nhấn
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục bài viết");
                }
            }

            return RedirectToAction("Index", "Menu");
        }

    }
}