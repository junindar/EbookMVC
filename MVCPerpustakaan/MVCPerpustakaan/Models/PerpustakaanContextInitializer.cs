
using System.Collections.Generic;


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
                            Status=true,Gambar="xamarin-android.jpg" },
                        new Buku { Judul = "XAMARIN.FORMS - Membangun Aplikasi Mobile Cross-Platform",
                            Penulis ="Junindar",Penerbit ="EBOOKUID",Deskripsi="",
                            Status =true,Gambar="xamarin-form.jpg" },
                        new Buku { Judul = "VISUAL BASIC 2015 - Cara Cepat Membangun Aplikasi Interaktif",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status =true,Gambar="vb-2015.jpg" },
                        new Buku { Judul = "Membangun Aplikasi Point Of Sale (POS) Lebih Mudah Dan Cepat",
                            Penulis ="Junindar",Penerbit="EBOOKUID",Deskripsi="",
                            Status =true,Gambar="c-dapper.jpg" },
                        new Buku { Judul = "Visual Studio LightSwitch Learning By Doing",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="Ls1.jpg" },
                        new Buku { Judul = "Will Code With LightSwitch",Penulis="Junindar",Penerbit="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="Ls2.jpg" },
                        new Buku { Judul = "Visual Studio LightSwitch - HTML Client",Penulis="Junindar",Penerbit="EBOOKUID",
                            Deskripsi ="",
                            Status=true,Gambar="Ls3.jpg" },
                        new Buku { Judul = "Visual Studio LightSwitch - Edisi Bundling",Penulis="Junindar",
                            Penerbit ="EBOOKUID",Deskripsi="",
                            Status=true,Gambar="Ls4.jpg" }
                }
            };

            var kategori2 = new Kategori()
            {
                NamaKategori = "Sosial",
                Bukus = new List<Buku>()
                {
                     new Buku { Judul = "Raga Kayu Jiwa Manusia",
                            Penulis ="Sarah Anais Andrieu",
                            Penerbit ="Kepustakaan Populer Gramedia",
                            Deskripsi =@"Wayang golek purwa kini sangat populer di Tanah Sunda, Jawa Barat, Indonesia. 
                            Praktik yang kompleks dalam dimensi sosial dan artistiknya ini diproklamasikan oleh UNESCO 
                            sebagai Karya Agung Warisan Budaya Lisan dan Takbenda Manusia yang merupakan bagian dari pencalonan umum “Wayang Indonesia”, pada tahun 2003.
                            Buku ini menguraikan dan membahas jalur yang dilalui suatu warisan keluarga hingga menjadi suatu warisan bersama, nasional, dan dunia. 
                            Analisis antropologi ini memadukan kajian politik budaya di tingkat-tingkat tersebut dengan 
                            kajian konsep-konsep global dan studi mendalam mengenai tahapan pencalonan pertama Indonesia pada warisan takbenda UNESCO, 
                            serta realitas etnografi wayang golek. Dari proses warisanisasi resmi (yaitu proses menjadi warisan) itu muncul banyak kepentingan, 
                            seperti pembentukan identitas dan budaya nasional, atau pula spektakularisasi dan folklorisasi wayang golek, perubahannya menjadi sebuah produk ekspor, suatu sumber daya untuk digerakkan dan didayagunakan.",
                            Status=true,Gambar="sosial1.jpg" },
                      new Buku { Judul = "Generasi Phi",
                            Penulis ="Dr.Muhammad Faizal",
                            Penerbit ="Republika Penerbit",
                            Deskripsi ="",
                            Status=true,Gambar="sosial2.jpg" }
                }
            };

            context.Kategoris.Add(kategori1);
            context.Kategoris.Add(kategori2);

            base.Seed(context);
        }


    }
}