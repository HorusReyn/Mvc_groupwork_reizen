using Microsoft.AspNetCore.Identity;

namespace ZiekefondsReizen.ViewModels
{
    public class AccountCreateViewModel
    {
        [Required]
        public string Voornaam { get; set; }
        [Required]

        public string Achternaam { get; set; }
        [Required]

        public string Straat { get; set; }
        [Required]

        public string Huisnummer { get; set; }
        [Required]

        public string Gemeente { get; set; }
        [Required]

        public string Postcode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Geboortedatum { get; set; }
        [Required]

        public string Huisdoktor { get; set; }

        public string ContractNummer { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string TelefoonNummer { get; set; }

        
        public string RekeningNummer { get; set; }
        [Required]
        [StringLength(40,MinimumLength = 6,ErrorMessage ="het {0} moet {2} en maximum {1} karakters lang zijn")]
        [DataType(DataType.Password)]
        [Compare("ConfirmWachtwoord",ErrorMessage ="Wachtwoorden zijn niet aan elkaar gelijk")]
        public string Wachtwoord { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmWachtwoord { get; set; }
    }
}
