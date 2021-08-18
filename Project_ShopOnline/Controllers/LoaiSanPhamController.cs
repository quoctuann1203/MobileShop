using PagedList;
using Project_ShopOnline.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ShopOnline.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(String id, int page = 1, int pagesize = 6)
        {
            var ds = LoaiSanPhamDB.ChiTiet(id).ToPagedList(page, pagesize);
            return View(ds);
        }
    }
}