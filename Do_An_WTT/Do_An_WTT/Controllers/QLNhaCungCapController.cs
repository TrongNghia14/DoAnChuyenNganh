using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_WTT.Models;

namespace Do_An_WTT.Controllers
{
    public class QLNhaCungCapController : Controller
    {
		qlBanCaCanhDataContext dt = new qlBanCaCanhDataContext();
		// GET: QLNhaCungCap
		public ActionResult Index()
        {
			var data = dt.NHACUNGCAPs.ToList();
			return View(data);
		}

        // GET: QLNhaCungCap/Details/5
        public ActionResult Details(int id)
        {
			var databyid = dt.NHACUNGCAPs.Single(x => x.MaNCC == id);
			return View(databyid);
		}

        // GET: QLNhaCungCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLNhaCungCap/Create
        [HttpPost]
        public ActionResult Create(NHACUNGCAP collection)
        {
            try
            {
				dt.NHACUNGCAPs.InsertOnSubmit(collection);
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLNhaCungCap/Edit/5
        public ActionResult Edit(int id)
        {
			var databyid = dt.NHACUNGCAPs.Single(x => x.MaNCC == id);
			return View(databyid);
		}

        // POST: QLNhaCungCap/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NHACUNGCAP collection)
        {
            try
            {
				NHACUNGCAP ncc = dt.NHACUNGCAPs.Single(x => x.MaNCC == id);
				ncc.TenNCC = collection.TenNCC;
				ncc.DienThoai = collection.DienThoai;
				ncc.DiaChi = collection.DiaChi;
				ncc.Email = collection.Email;
				dt.SubmitChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QLNhaCungCap/Delete/5
        public ActionResult Delete(int id)
        {
			var databyid = dt.NHACUNGCAPs.Single(x => x.MaNCC == id);
			return View(databyid);
		}

        // POST: QLNhaCungCap/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NHACUNGCAP collection)
        {
            try
            {
				var data = dt.NHACUNGCAPs.Single(x => x.MaNCC == id);
				dt.NHACUNGCAPs.DeleteOnSubmit(data);
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
