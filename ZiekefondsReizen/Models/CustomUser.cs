using Microsoft.AspNetCore.Identity;
using ZiekefondsReizen.Models;

namespace ZiekefondsReizen.Models
{
    public class CustomUser : IdentityUser
    {

        [Required]
        public override string Id {  get; set; }

        public string? Voornaam { get; set; }
        [PersonalData]
        public string? Achternaam { get; set; }
        [PersonalData]
        public string? Straat { get; set; }
        [PersonalData]
        public string? Huisnummer { get; set; }
        [PersonalData]
        public string? Gemeente { get; set; }
        [PersonalData]
        public string? Postcode { get; set; }
        [PersonalData]
        public DateOnly? Geboortedatum { get; set; }
        [PersonalData]
        public string? Huisdoktor { get; set; }
        [PersonalData]
        public string? ContractNummer { get; set; }
        [PersonalData]
        public string? TelefoonNummer { get; set; }
        [PersonalData]
        public string? RekeningNummer { get; set; }
        [PersonalData]
        public Boolean? IsActief { get; set; }
        public Boolean? IsHoofdMonitor { get; set; }

    }
}