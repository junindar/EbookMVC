using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCPerpustakaan.Helpers;
using MVCPerpustakaan.Models;
using MVCPerpustakaan.ViewModels;

namespace MVCPerpustakaan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();
        public ActionResult Index()
        {
            var listBuku = db.Bukus.OrderBy(r => Guid.NewGuid()).Take(6).ToList();
            return View(listBuku);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DaftarBuku()
        {
            var listBuku = db.Bukus.Where(
               c => c.Kategori.NamaKategori.ToLower().
               Equals("teknologi")).ToList();
            return View(listBuku);
        }

        [HttpGet]
        public ActionResult GetBukuByCategory(string category)
        {
            var listBuku = db.Bukus.Where(
                c => c.Kategori.NamaKategori.ToLower().Equals(category.ToLower())).ToList();

                return PartialView("~/Views/Shared/_GetBuku.cshtml", listBuku);

        }

        [HttpPost]
        public ActionResult AddShoppingCart(Buku buku)
        {
            var jumlahBuku = 0;
            var bukuList = SessionManager.Get<List<Buku>>("ShoppingCart");
            string messageUser;
            try
            {
                if (buku != null)
                {
                    if (bukuList != null)
                    {
                        var isDuplicate = bukuList.Any(c => c.BukuId.Equals(buku.BukuId));
                        if (isDuplicate)
                        {
                            messageUser = "Buku telah ada didalam keranjang anda !";
                        }
                        else
                        {
                            bukuList.Add(buku);
                            messageUser = "Buku telah sukses dimasukkan kedalam keranjang anda !";
                        }
                    }
                    else
                    {
                        bukuList = new List<Buku> {buku};
                       // jumlah = bukuList.Count;
                        messageUser = "Buku telah sukses dimasukkan kedalam keranjang anda !";
                    }
                    jumlahBuku = bukuList.Count;
                }
                else
                {
                    messageUser = "Coba kembali, terjadi kesalahan pada sistem  !";
                }
            }
            catch (Exception ex)
            {
                messageUser = ex.Message;
            }
           
            SessionManager.Set("ShoppingCart", bukuList);
            return Json(new { message = messageUser,
                jumlah = jumlahBuku
            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DisplayMyOrder()
        {
            List<Buku> myOrder = SessionManager.Get<List<Buku>>("ShoppingCart");
            return View( myOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisplayMyOrder(string answer)
        {

            if (answer == "Save")
            {
                try
                {
                    List<Buku> bukuList = SessionManager.Get<List<Buku>>("ShoppingCart");
                   
                    var details = bukuList.Select(buku => new OrderDetail()
                    {
                        BukuId = buku.BukuId
                    }).ToList();



                    var order = new Order()
                    {
                        OrderDate = DateTime.Now,
                        Username= SessionManager.Get<string>("Username"),
                        OrderDetails = details
                    };
                    db.Orders.Add(order);

                    foreach (var buku in bukuList)
                    {
                        var bukuUpdate = db.Bukus.FirstOrDefault(b => b.BukuId == buku.BukuId);
                        bukuUpdate.Status = false;
                    }

                    db.SaveChanges();
                    SessionManager.Remove("ShoppingCart");
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
                SessionManager.Remove("ShoppingCart");
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DisplayHistory()
        {
            try
            {
                var curUsername = SessionManager.Get<string>("Username");
               
                var historyList = (from od in db.OrderDetails
                               join o in db.Orders on od.OrderId equals o.OrderId
                                join b in db.Bukus on od.BukuId equals  b.BukuId
                            where o.Username.ToLower().Equals(curUsername.ToLower())
                                   select new HistoryVM()
                                   {
                                       BukuId = od.BukuId,
                                       Judul = b.Judul,
                                       Penulis = b.Penulis,
                                       Gambar = b.Gambar,
                                       Status = o.Closed ? "Sudah Kembali" : "Masih Dipinjam",
                                       OrderDate = o.OrderDate,
                                       ReturnDate =  o.ReturnDate

                                   }).ToList();
                return View(historyList);
               
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to process. " + ex.Message);
                ViewBag.Success = "Error";
            }
           

            return View();
        }
        
        public ActionResult DetailBuku(int id)
        {
            try
            {
                var buku = db.Bukus.FirstOrDefault(b => b.BukuId.Equals(id));
                if (buku == null)
                {
                    ModelState.AddModelError("", "Buku tidak dapat ditampilkan.");
                    return View();
                }
                else
                {
                    return View(buku);
                }
               
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to process. " + ex.Message);
            }
            return View();
        }
    }
}