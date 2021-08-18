using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ShopOnline.Models.DB
{
    public class GioHangDB
    {
        public static void Them(string masanpham, string tensanpham, int gia,int soluong)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                var x = db.Query<GioHang>("select * from GioHang Where MaSanPham = '" + masanpham + "'").ToList();
                if (x.Count() > 0)
                {
                    //Goi ham update so luong
                    int a = (int)x.ElementAt(0).SoLuong + soluong;
                    CapNhat(masanpham, tensanpham, a, gia);
                }
                else
                {
                    GioHang giohang = new GioHang()
                    {
                        MaSanPham = masanpham,
                        TenSanPham = tensanpham,
                        Gia = gia,
                        SoLuong = soluong,
                        TongTien = gia * soluong
                    };
                    db.Insert(giohang);
                }

            }
        }

        public static void CapNhat(string masanpham, string tensanpham, int gia, int soluong)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                GioHang giohang = new GioHang()
                {
                    MaSanPham = masanpham,
                    TenSanPham = tensanpham,
                    Gia = gia,
                    SoLuong = soluong,
                    TongTien = gia * soluong
                };
                var tamp = db.Query<GioHang>("Select idGioHang from GioHang Where MaSanPham = '" + masanpham + "'").FirstOrDefault();
                db.Update(giohang, tamp.IdGioHang);
            }
        }


        public static IEnumerable<GioHang> DanhSach()
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                //return db.Query<GioHang>("Select * from GioHang");
                return db.Query<GioHang>("select * from GioHang G inner join SanPham S on G.MaSanPham = S.MaSanPham");
                
            }
        }


        public static void Xoa(string masanpham)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                var a = db.Query<GioHang>("select * from GioHang where MaSanPham = '" + masanpham + "'").FirstOrDefault();
                db.Delete(a);
            }
        }
        public static int TongTien()
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                List<GioHang> a = DanhSach().ToList();
                if (a.Count() == 0)
                {
                    return 0;
                }
                return db.Query<int>("Select sum(TongTien) from GioHang").FirstOrDefault();
            }
        }
    }
}