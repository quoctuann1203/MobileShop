using Project_ShopOnline.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ShopOnline.Controllers
{
    
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            ViewBag.TongTien = GioHangDB.TongTien();
            return View(GioHangDB.DanhSach());
        }

        [HttpPost]
        public ActionResult Them(string masanpham, string tensanpham, int gia, int soluong)
        {
            try
            {
                GioHangDB.Them(masanpham, tensanpham, gia, soluong);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Shop/Index");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(string masanpham, string tensanpham, int gia, int soluong)
        {
            try
            {
                GioHangDB.CapNhat(masanpham, tensanpham, gia, soluong);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }
        [HttpGet]
        public ActionResult Xoa(string masanpham)
        {
            try
            {
                GioHangDB.Xoa(masanpham);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }

        // GET: GioHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GioHang/Delete/5
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
