

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
                NoTelp = "08777777"
            });
            context.Category.Add(new Category { NamaCategory = "Umum" });
            context.Category.Add(new Category { NamaCategory = "Teknologi" });
            context.Category.Add(new Category { NamaCategory = "Sosial" });

            base.Seed(context);
        }

    }
}