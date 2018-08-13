using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCModel.Models
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

        public Kategori Kategori { get; set; }
    }
}