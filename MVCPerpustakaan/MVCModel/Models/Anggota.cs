
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCModel.Models
{
    public class Anggota
    {
        public int AnggotaId { get; set; }
        [Required(ErrorMessage = "Field {0} tidak boleh kosong")]
        [StringLength(150, MinimumLength=3, ErrorMessage = "Minimum karakter 3 dan Maksimun karakter 150")]
        [Display(Name = "Nama")]
        public string NamaAnggota { get; set; }
        [Range(17, 65, ErrorMessage = "Umur harus lebih besar atau sama dengan dari 17 dan lebih kecil atau sama dengan 65")]
        public int Umur { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Lahir")]
        public DateTime TanggalLahir { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Daftar")]
        public DateTime TanggalDaftar { get; set; }
        [DataType(DataType.MultilineText)]
        public string Alamat { get; set; }
        
        [Display(Name = "No Telp.")]
        public string NoTelp { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Format Email salah.")]
        public string Email { get; set; }
        [NotMapped]
        [Compare("Email", ErrorMessage = "Email Confirm harus sama dengan Email")]
        [Display(Name = "Email Confirm")]
        public string EmailConfirm { get; set; }
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [Range(50000, double.MaxValue,ErrorMessage = "Jumlah Deposito harus lebih besar atau sama dengan 50000")]
        public decimal Deposito { get; set; }
        public bool Status { get; set; }
        //[DataType(DataType.Password)]

       

    }
}