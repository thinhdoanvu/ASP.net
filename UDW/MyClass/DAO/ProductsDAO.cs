using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    public class ProductsDAO
    {
        private MyDBContext db = new MyDBContext();

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo san pham theo tung Categories (catid)
        public List<Products> getListByCatId(int catid, int limit)
        {
            List<Products> list = db.Products
                .Where(m => m.CatID == catid && m.Status == 1)
                .Take(limit)
                .OrderByDescending(m => m.CreateBy)
                .ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo san pham theo tung Categories (catid)
        public List<Products> getListByListCatId(List<int> listcatid, int limit)
        {
            List<Products> list = db.Products
                .Where(m=> m.Status == 1 && listcatid.Contains(m.CatID))
                .Take(limit)
                .OrderByDescending(m => m.CreateBy)
                .ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo Loai san pham: SELCT * FROM
        public List<Products> getList(string status = "All")
        {
            List<Products> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Products
                        .Where(m => m.Status != 0)
                        .ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Products
                        .Where(m => m.Status == 0)
                        .ToList();
                        break;
                    }
                default:
                    {
                        list = db.Products.ToList();
                        break;
                    }
            }
            return list;
        }
        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Products getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Products.Find(id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Products getRow(string slug)
        {

            return db.Products
                .Where(m=>m.Slug == slug && m.Status ==1)
                .FirstOrDefault();

        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Them moi mot mau tin
        public int Insert(Products row)
        {
            db.Products.Add(row);
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Cap nhat mot mau tin
        public int Update(Products row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Xoa mot mau tin Xoa ra khoi CSDL
        public int Delete(Products row)
        {
            db.Products.Remove(row);
            return db.SaveChanges();
        }
    }
}
