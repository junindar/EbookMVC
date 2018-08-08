using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCModel.Models;

namespace MVCModel.Controllers
{
    public class AnggotaController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();

        // GET: Anggota
        public ActionResult Index()
        {
            return View(db.Anggota.ToList());
        }
        //
        // GET: Anggota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anggota anggota = db.Anggota.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        // GET: Anggota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnggotaId,NamaAnggota," +
                                                   "Umur,Alamat,NoTelp")] Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                db.Anggota.Add(anggota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anggota);
        }

        // GET: Anggota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anggota anggota = db.Anggota.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        // POST: Anggota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnggotaId,NamaAnggota,Umur,Alamat,NoTelp")] Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anggota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anggota);
        }

        // GET: Anggota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anggota anggota = db.Anggota.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        // POST: Anggota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anggota anggota = db.Anggota.Find(id);
            db.Anggota.Remove(anggota);
            db.SaveChanges();
            return RedirectToAction("Index");
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
