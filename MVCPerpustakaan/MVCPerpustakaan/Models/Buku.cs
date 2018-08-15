
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVCPerpustakaan.Models
{
    public class Buku
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Judul Buku")]
        public string Judul { get; set; }

        [Required]
        [Display(Name = "Nama Penulis")]
        public string Penulis { get; set; }

        [Required]
        [Display(Name = "Nama Penerbit")]
        public string Penerbit { get; set; }

        [DataType(DataType.MultilineText)]
        public string Deskripsi { get; set; }

        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Kategori")]
        public virtual Kategori Kategori { get; set; }


        [Display(Name = "Status Buku")]
        public bool Status { get; set; }

        [DisplayName("Gambar Buku")]
        [DataType(DataType.Upload)]
        public string Gambar { get; set; }
    }
}