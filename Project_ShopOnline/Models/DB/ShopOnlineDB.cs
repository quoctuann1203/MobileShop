using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ShopOnline.Models.DB
{
    public class ShopOnlineDB
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham where TinhTrang = 0");
        }
        public static SanPham ChiTiet(String a)
        {
            var db = new ShopOnlineConnectionDB();
            return db.SingleOrDefault<SanPham> ("select * from SanPham where MaSanPham = @0",a);
        }

        public static IEnumerable<SanPham> BestSeller()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select Top 4* from SanPham order by SoLuongDaBan desc");
        }

        public static IEnumerable<SanPham> TopHot()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select Top 4* from SanPham order by LuotView desc");
        }

        //---------------------- Admin -----------------
        public static IEnumerable<SanPham> DanhSachSP()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham");
        }

        public static void CreateSP(SanPham sp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Insert(sp);
        }

        public static void UpdateSP(String id ,SanPham sp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Update(sp,id);
        }
    }
}