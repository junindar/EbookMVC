
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

        [HiddenInput]
        public int KategoriId { get; set; }

        [Required]
        [Display(Name = "Kategori Buku")]
        public Kategori Kategori { get; set; }

        [Display(Name = "Jumlah Buku")]
        [Range(0, Int32.MaxValue)]
        public string Jumlah { get; set; }
    }
}