using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_WTT.Models;

namespace Do_An_WTT.Controllers
{
    public class QLLoaiCaController : Controller
    {
		qlBanCaCanhDataContext dt = new qlBanCaCanhDataContext();
		// GET: QLLoaiCa
		public ActionResult Index()
        {
			var data = dt.PHANLOAIs.ToList();
			return View(data);
		}

        // GET: QLLoaiCa/Details/5
        public ActionResult Details(int id)
        {
			var databyid = dt.PHANLOAIs.Single(x => x.MaLoai == id);
			return View(databyid);
		}

        // GET: QLLoaiCa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLLoaiCa/Create
        [HttpPost]
        public ActionResult Create(PHANLOAI collection)
        {
            try
            {
				dt.PHANLOAIs.InsertOnSubmit(collection);
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLLoaiCa/Edit/5
        public ActionResult Edit(int id)
        {
			var databyid = dt.PHANLOAIs.Single(x => x.MaLoai == id);
			return View(databyid);
        }

        // POST: QLLoaiCa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PHANLOAI collection)
        {
            try
            {
				PHANLOAI pl = dt.PHANLOAIs.Single(x => x.MaLoai == id);
				pl.TenLoai = collection.TenLoai;
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLLoaiCa/Delete/5
        public ActionResult Delete(int id)
        {
			var databyid = dt.PHANLOAIs.Single(x => x.MaLoai == id);
			return View(databyid);
		}

        // POST: QLLoaiCa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PHANLOAI collection)
        {
            try
            {
				var data = dt.PHANLOAIs.Single(x => x.MaLoai == id);
				dt.PHANLOAIs.DeleteOnSubmit(data);
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
