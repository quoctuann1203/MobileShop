using PagedList;
using Project_ShopOnline.Models.DB;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(ShopOnlineDB.DanhSachSP());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatDB.List(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamDB.List(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSanPham + ".png";
                }
                sp.LuotView = 0;
                sp.SoLuongDaBan = 0;

                // TODO: Add insert logic here
                ShopOnlineDB.CreateSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatDB.List(), "MaNhaSanXuat", "TenNhaSanXuat",ShopOnlineDB.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamDB.List(), "MaLoaiSanPham", "TenLoaiSanPham", ShopOnlineDB.ChiTiet(id).MaLoaiSanPham);
            return View(ShopOnlineDB.ChiTiet(id));
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            try
            {
                //var hpf = HttpContext.Request.Files[0];
                //if (hpf.ContentLength > 0)
                //{
                //    string fileName = sp.MaSanPham;

                //    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                //    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                //    sp.HinhChinh = sp.MaSanPham + ".png";
                //}
                //if(sp.SoLuongDaBan > 10000)
                //{
                //    sp.SoLuongDaBan = 0;
                //}

                //if(sp.LuotView > 10000)
                //{
                //    sp.LuotView = 0;
                //}
                ShopOnlineDB.UpdateSP(id, sp);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Admin/Product/Lock/5
        public ActionResult Lock(String id)

        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatDB.List(), "MaNhaSanXuat", "TenNhaSanXuat", ShopOnlineDB.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamDB.List(), "MaLoaiSanPham", "TenLoaiSanPham", ShopOnlineDB.ChiTiet(id).MaLoaiSanPham);
            return View(ShopOnlineDB.ChiTiet(id));
        }

        // POST: Admin/Product/Lock/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Lock(String id, SanPham sp)
        {
            try
            {
                // TODO: Add delete logic here
                sp.TinhTrang = "1";
                ShopOnlineDB.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ShopOnlineDB.ChiTiet(id));
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, SanPham sp) 
        {
            try
            {
                // TODO: Add delete logic here
                sp.TinhTrang = "1";
                ShopOnlineDB.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
