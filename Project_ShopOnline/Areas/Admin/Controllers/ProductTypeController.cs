using Project_ShopOnline.Models.DB;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ShopOnline.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        // GET: Admin/ProductType
        public ActionResult Index()
        {
            var db = LoaiSanPhamDB.ListAdmin();
            return View(db);
        }

        // GET: Admin/ProductType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductType/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamDB.CreateLSP(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductType/Edit/5
        public ActionResult Edit(String id)
        {
            //load db theo id
            var db = LoaiSanPhamDB.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/ProductType/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamDB.UpdateLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //------LOCK-----

        // GET: Admin/ProductType/Lock/5
        public ActionResult Lock(String id)
        {
            var db = LoaiSanPhamDB.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/ProductType/Lock/5
        [HttpPost]
        public ActionResult Lock(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                lsp.TinhTrang = "1";
                LoaiSanPhamDB.UpdateLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        // GET: Admin/ProductType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProductType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
