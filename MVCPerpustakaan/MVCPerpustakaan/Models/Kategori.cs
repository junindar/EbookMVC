using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace MVCPerpustakaan.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        [Required]
        [Display(Name = "Nama Kategori")]
        public string NamaKategori { get; set; }

        public List<Buku> Bukus { get; set; }
    }
}