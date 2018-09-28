using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPerpustakaan.Helpers;
using MVCPerpustakaan.Models;
using MVCPerpustakaan.ViewModels;

namespace MVCPerpustakaan.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class BukuController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();

        // GET: Buku
        public ActionResult Index()
        {
            var bukus = db.Bukus.Include(b => b.Kategori);
            return View(bukus.ToList());
        }

        // GET: Buku/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        // GET: Buku/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "NamaKategori");
            return View();
        }

        // POST: Buku/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Buku buku,
            HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    buku.Gambar = Path.GetFileName(ImageFile.FileName);
                }

                db.Bukus.Add(buku);
                db.SaveChanges();
                if (ImageFile == null) return RedirectToAction("Index");
                string fileName = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(
                    Server.MapPath("~/Images"), fileName);
                ImageFile.SaveAs(path);

                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoris, 
                "KategoriId", "NamaKategori", buku.KategoriId);
            return View(buku);
        }

        // GET: Buku/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "NamaKategori", buku.KategoriId);
            return View(buku);
        }

        // POST: Buku/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Buku buku, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    buku.Gambar = Path.GetFileName(ImageFile.FileName);
                }
                db.Entry(buku).State = EntityState.Modified;
                db.SaveChanges();

                if (ImageFile == null) return RedirectToAction("Index");
                string fileName = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(
                    Server.MapPath("~/Images"), fileName);
                ImageFile.SaveAs(path);
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "NamaKategori", buku.KategoriId);
            return View(buku);
        }

        // GET: Buku/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        // POST: Buku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buku buku = db.Bukus.Find(id);
            db.Bukus.Remove(buku);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DaftarPeminjam()
        {
            try
            {
                var peminjamList = (from o in db.Orders
                                    join u in db.Users on o.Username equals u.Username
                                    select new PeminjamanVM()
                                    {
                                        OrderId = o.OrderId,
                                        Peminjam = u.Nama,
                                        Status = o.Closed ? "Closed" : "Open",
                                        OrderDate = o.OrderDate,
                                        ReturnDate = o.ReturnDate

                                    }).ToList();
                return View(peminjamList);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to process. " + ex.Message);
                ViewBag.Success = "Error";
            }


            return View();
        }

        public ActionResult DetailPeminjaman(int id)
        {
            try
            {

                var detail = (from od in db.OrderDetails
                              join o in db.Orders on od.OrderId equals o.OrderId
                              join b in db.Bukus on od.BukuId equals b.BukuId
                              where o.OrderId.Equals(id)
                              select new PeminjamanDetailVM()
                              {
                                  OrderId = o.OrderId,
                                  BukuId = b.BukuId,
                                  Judul = b.Judul,
                                  Penulis = b.Penulis,
                                  Gambar = b.Gambar,
                                  Status = o.Closed
                              }).ToList();

                SessionManager.Set("DetailPeminjaman", detail);
                return View(detail);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to process. " + ex.Message);
                ViewBag.Success = "Error";
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailPeminjaman(string answer)
        {

            if (answer == "Save")
            {
                try
                {
                    var details = SessionManager.Get<List<PeminjamanDetailVM>>("DetailPeminjaman");
                    var id = details.First().OrderId;


                    var order = db.Orders.FirstOrDefault(c => c.OrderId.Equals(id));
                    order.Closed = true;
                    order.ReturnDate = DateTime.Now;
                    db.SaveChanges();

                    foreach (var buku in details)
                    {
                        var bukuUpdate = db.Bukus.FirstOrDefault(b => b.BukuId == buku.BukuId);
                        bukuUpdate.Status = true;
                    }

                    db.SaveChanges();
                    SessionManager.Remove("DetailPeminjaman");
                    ViewBag.Success = "Success";
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to process. " + ex.Message);
                    ViewBag.Success = "Error";
                }

            }
            else
            {
                return RedirectToAction("DaftarPeminjam", "Buku");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
