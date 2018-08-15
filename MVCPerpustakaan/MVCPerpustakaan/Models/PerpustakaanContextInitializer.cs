using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPerpustakaan.Models
{
    public class PerpustakaanContextInitializer :
        System.Data.Entity.DropCreateDatabaseAlways<PerpustakaanContext>
    {
        protected override void Seed(PerpustakaanContext context)
        {

            var users = new List<User>
            {
                new User
                {
                    Username = "Admin",
                    Nama = "Junindar",
                    Password = "123456",
                    Role = "Admin",
                    Status = true
                },
                 new User
                {
                    Username = "andi",
                    Nama = "Andi F",
                    Password = "123456",
                    Role = "Staff",
                    Status = true
                },
                  new User
                {
                    Username = "rian",
                    Nama = "Rian A",
                    Password = "123456",
                    Role = "General",
                    Status = true
                }

            };

            users.ForEach(a => context.Users.Add(a));

            var kategoris = new List<Kategori>
            {
                new Kategori { NamaKategori = "Agama" },
                new Kategori { NamaKategori = "Bahasa" },
                new Kategori { NamaKategori = "Sosial" }

            };
            kategoris.ForEach(a => context.Kategoris.Add(a));

            var kategori1 = new Kategori()
            {
                NamaKategori = "Teknologi",
                Bukus = new List<Buku>()
                {
                        new Buku { Judul = "XAMARIN ANDROID - Mudah Membangung Aplikasi Mobile",
                            Penulis ="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="" },
                        new Buku { Judul = "XAMARIN.FORMS - Membangun Aplikasi Mobile Cross-Platform",
                            Penulis ="Junindar",Penerbit ="EBOOKUID",Deskripsi="",Status=true,Gambar="" },
                        new Buku { Judul = "VISUAL BASIC 2015 - Cara Cepat Membangun Aplikasi Interaktif",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",Status=true,Gambar="" },
                        new Buku { Judul = "Membangun Aplikasi Point Of Sale (POS) Lebih Mudah Dan Cepat",
                            Penulis ="Junindar",Penerbit="EBOOKUID",Deskripsi="",Status=true,Gambar="" },
                        new Buku { Judul = "Visual Studio LightSwitch Learning By Doing",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="" },
                        new Buku { Judul = "Will Code With LightSwitch",Penulis="Junindar",Penerbit="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="" },
                        new Buku { Judul = "Visual Studio LightSwitch - HTML Client",Penulis="Junindar",Penerbit="EBOOKUID",
                            Deskripsi ="",
                            Status=true,Gambar="" },
                        new Buku { Judul = "Visual Studio LightSwitch - Edisi Bundling",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="" }
                }
            };

            context.Kategoris.Add(kategori1);


            base.Seed(context);
        }


    }
}