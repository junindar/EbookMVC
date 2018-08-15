using System.ComponentModel.DataAnnotations;


namespace MVCPerpustakaan.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}