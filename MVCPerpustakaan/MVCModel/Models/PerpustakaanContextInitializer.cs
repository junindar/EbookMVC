using System;

namespace MVCModel.Models
{
    public class PerpustakaanContextInitializer :
        System.Data.Entity.DropCreateDatabaseIfModelChanges<PerpustakaanContext>
    {

        protected override void Seed(PerpustakaanContext context)
        {
            context.Anggota.Add(new Anggota
            {
                NamaAnggota = "Junindar",
                Alamat = "Jln. Indah dan Permai No. 50",
                Umur = 35,
                TanggalLahir = DateTime.Now,
                TanggalDaftar = DateTime.Now,
                NoTelp = "08777777",
                Email = "junindar@gmail.com",
                EmailConfirm =  "junindar@gmail.com",
                JenisKelamin = "Pria",
                Deposito = 100000,
                Status = true

            });
            context.Category.Add(new Kategori { NamaCategory = "Umum" });
            context.Category.Add(new Kategori { NamaCategory = "Teknologi" });
            context.Category.Add(new Kategori { NamaCategory = "Sosial" });

            base.Seed(context);
        }

    }
}