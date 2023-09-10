using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;

namespace UDW.Controllers
{
    public class SiteController : Controller
    {
        LinksDAO linksDAO = new LinksDAO();
        /////////////////////////////////////////////////////////////////////////////
        // GET: Site
        public ActionResult Index(string slug = null)
        {
            if (slug == null)
            {
                //chuyen ve trang chu
                return this.Home();
            }
            else
            {
                //tim slug co trong bang link
                Links links = linksDAO.getRow(slug);
                //kiem tra slug co ton tai trong bang Links hay khong
                if (links!=null)
                {
                    //lay ra Type trong bang link
                    string typelink = links.Type;
                    switch (typelink)
                    {
                        case "category":
                            {
                                return this.ProductCategory(slug);
                            }
                        case "topic":
                            {
                                return this.PostTopic(slug);
                            }
                        case "page":
                            {
                                return this.PostPage(slug);
                            }
                        default:
                            {
                                return this.Error404(slug);
                            }
                    }
                }
                else
                {
                    //slug khong co trong bang Links
                    //slug co trong bang product?
                    //slug co trong bang Post voi PostType==post?
                    ProductsDAO productsDAO = new ProductsDAO();
                    PostsDAO postsDAO = new PostsDAO();

                    //tim slug co trong bang Products
                    Products products = productsDAO.getRow(slug);
                    if (products!=null)
                    {
                        return this.ProductDetail(products);
                    }
                    else
                    {
                        Posts posts = postsDAO.getRow(slug);
                        if (posts!=null)
                        {
                            return this.PostDetail(posts);
                        }
                        else
                        {
                            return this.Error404(slug);
                        }
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        //Trang chu
        public ActionResult Home()
        {
            return View("Home");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/Product
        public ActionResult Product()
        {
            return View("Product");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/Post
        public ActionResult Post()
        {
            return View("Post");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/ProductCategory
        public ActionResult ProductCategory(string slug)
        {
            return View("ProductCategory");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/PostTopic
        public ActionResult PostTopic(string slug)
        {
            return View("PostTopic");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/PostPage
        public ActionResult PostPage(string slug)
        {
            return View("PostPage");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Site/Error404
        public ActionResult Error404(string slug)
        {
            return View("Error404");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Product/Details
        public ActionResult ProductDetail(Products products)
        {
            return View("ProductDetail");
        }

        /////////////////////////////////////////////////////////////////////////////
        //Post/Details
        public ActionResult PostDetail(Posts posts)
        {
            return View("PostDetail");
        }
    }
}