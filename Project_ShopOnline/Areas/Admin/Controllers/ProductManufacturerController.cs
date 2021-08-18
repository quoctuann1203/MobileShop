using Project_ShopOnline.Models.DB;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ShopOnline.Areas.Admin.Controllers
{
    public class ProductManufacturerController : Controller
    {
        // GET: Admin/ProductManufacturer
        public ActionResult Index()
        {
            var ds = NhaSanXuatDB.ListAdmin();
            return View(ds);
        }

        // GET: Admin/ProductManufacturer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProductManufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductManufacturer/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add insert logic here
                NhaSanXuatDB.CreateNSX(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductManufacturer/Edit/5
        public ActionResult Edit(String id)
        {
            return View(NhaSanXuatDB.ChiTietAdmin(id));
        }

        // POST: Admin/ProductManufacturer/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatDB.UpdateNSX(id,nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //-----Khoa NSX------
        public ActionResult Lock(String id)
        {
            return View(NhaSanXuatDB.ChiTietAdmin(id));
        }


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

        // GET: Admin/ProductManufacturer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProductManufacturer/Delete/5
        [HttpPost]
        public ActionResult Lock(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add delete logic here
                nsx.TinhTrang = "1";
                NhaSanXuatDB.UpdateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
