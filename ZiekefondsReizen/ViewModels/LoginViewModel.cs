namespace ZiekefondsReizen.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email mag niet leeg zijn")]
        [EmailAddress]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Wachtwoord mag niet leeg zijn")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Onthoud mij?")]
        public bool RememberMe { get; set; }
    }

}
