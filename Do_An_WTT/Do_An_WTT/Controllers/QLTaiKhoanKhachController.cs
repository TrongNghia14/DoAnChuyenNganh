using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_WTT.Models;

namespace Do_An_WTT.Controllers
{
    public class QLTaiKhoanKhachController : Controller
    {
		qlBanCaCanhDataContext dt = new qlBanCaCanhDataContext();
        // GET: QLTaiKhoanKhach
        public ActionResult Index()
		{
			var data = dt.KHACHHANGs.ToList();
			return View(data);
		}
        // GET: QLTaiKhoanKhach/Details/5
        public ActionResult Details(int id)
		{
			var databyid = dt.KHACHHANGs.Single(x => x.MaKH == id);
			return View(databyid);
		}
        // GET: QLTaiKhoanKhach/Create
        public ActionResult Create()
		{
            return View();
		}
        // POST: QLTaiKhoanKhach/Create
        [HttpPost]
        public ActionResult Create(KHACHHANG collection)
		{
            try
			{
				dt.KHACHHANGs.InsertOnSubmit(collection);
				dt.SubmitChanges();
                return RedirectToAction("Index");
			}
            catch{
                return View();
			}
		}
        // GET: QLTaiKhoanKhach/Edit/5
        public ActionResult Edit(int id)
		{
			var databyid = dt.KHACHHANGs.Single(x => x.MaKH == id);
			return View(databyid);
		}
        // POST: QLTaiKhoanKhach/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KHACHHANG collection)
		{
            try{
				KHACHHANG kh = dt.KHACHHANGs.Single(x => x.MaKH == id);
				kh.HoTen = collection.HoTen;
				kh.TaiKhoan = collection.TaiKhoan;
				kh.MatKhau = collection.MatKhau;
				kh.Email = collection.Email;
				kh.DiaChiKH = collection.DiaChiKH;
				kh.DienThoaiKH = collection.DienThoaiKH;
				kh.NgaySinh = collection.NgaySinh;
				dt.SubmitChanges();
				return RedirectToAction("Index");
			}
            catch{
                return View();
			}
		}
        // GET: QLTaiKhoanKhach/Delete/5
        public ActionResult Delete(int id)
		{
			var databyid = dt.KHACHHANGs.Single(x => x.MaKH == id);
			return View(databyid);
		}
        // POST: QLTaiKhoanKhach/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KHACHHANG collection)
		{
            try
			{
				var data = dt.KHACHHANGs.Single(x => x.MaKH == id);
				dt.KHACHHANGs.DeleteOnSubmit(data);
				dt.SubmitChanges();
				return RedirectToAction("Index");
			}
            catch
			{
                return View();
			}
        }
    }
}
