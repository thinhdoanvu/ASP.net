using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UDW.Library
{
    public class XCart
    {
        List<CartItem> list;
        public List<CartItem> AddCart(CartItem cartitem, int productid)
        {
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))//session chua co gio hang
            {
                List<CartItem> list = new List<CartItem>();
                list.Add(cartitem);
                System.Web.HttpContext.Current.Session["MyCart"] = list;
            }
            else
            {
                //da co thong tin trong gio hang, lay thong tin cua session -> ep  kieu ve list 
                List<CartItem> list = (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
                //kiewm tra productid da co trong danh sach hay chua
                int count = list.Where(m => m.ProductId == productid).Count();
                if (count > 0)//da co trong danh sach gio hang truoc do
                {
                    cartitem.Ammount += 1;
                    //cap nhat lai danh sach
                    int vt = 0;
                    foreach (var item in list)
                    {
                        if (item.ProductId == productid)
                        {
                            list[vt].Ammount += 1;
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = list;
                }
                else
                {
                    //them vao gio hang moi
                    list.Add(cartitem);
                    System.Web.HttpContext.Current.Session["MyCart"] = list;
                }
            }
            return list;
        }


        public void UpdateCart()
        {

        }

        public void DelCart()
        {

        }

        public List<CartItem> GetCart()
        {
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                return null;
            }
            return (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
        }
    }
}