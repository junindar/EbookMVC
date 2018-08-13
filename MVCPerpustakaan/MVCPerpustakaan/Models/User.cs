using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCPerpustakaan.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Nama Pengguna")]
        public string Nama { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "User Role")]
        public string Role { get; set; }

        public bool Status { get; set; }

    }
}