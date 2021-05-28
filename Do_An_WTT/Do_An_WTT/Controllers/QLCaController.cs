using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_WTT.Models;

namespace Do_An_WTT.Controllers
{
    public class QLCaController : Controller
    {
		// GET: QLCa
		qlBanCaCanhDataContext dt = new qlBanCaCanhDataContext();
        public ActionResult Index()
        {
			var data = dt.CAs.ToList();
			return View(data);
		}

        // GET: QLCa/Details/5
        public ActionResult Details(int id)
        {
			var databyid = dt.CAs.Single(x => x.MaCa == id);
			return View(databyid);
		}

        // GET: QLCa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLCa/Create
        [HttpPost]
        public ActionResult Create(CA collection)
        {
            try
            {
				dt.CAs.InsertOnSubmit(collection);
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLCa/Edit/5
        public ActionResult Edit(int id)
        {
			var databyid = dt.CAs.Single(x => x.MaCa == id);
			return View(databyid);
		}

        // POST: QLCa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CA collection)
        {
            try
            {
				CA ca = dt.CAs.Single(x => x.MaCa == id);
				ca.TenCa = collection.TenCa;
				ca.GiaBan = collection.GiaBan;
				ca.SoLuongTon = collection.SoLuongTon;
				ca.NgayCapNhap = collection.NgayCapNhap;
				ca.AnhBia = collection.AnhBia;
				ca.MoTa = collection.MoTa;
				ca.MaNCC = collection.MaNCC;
				ca.MaLoai = collection.MaLoai;
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLCa/Delete/5
        public ActionResult Delete(int id)
        {
			var databyid = dt.CAs.Single(x => x.MaCa == id);
			return View(databyid);
		}

        // POST: QLCa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CA collection)
        {
            try
            {
				var data = dt.CAs.Single(x => x.MaCa == id);
				dt.CAs.DeleteOnSubmit(data);
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
