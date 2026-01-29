namespace ZiekefondsReizen.ViewModels
{
    public class AccountEditViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public string Huisnummer { get; set; }

        public string Gemeente { get; set; }

        public string Postcode { get; set; }

        public DateTime Geboortedatum { get; set; }

        public string Huisdoktor { get; set; }

        public string ContractNummer { get; set; }

        public string Email { get; set; }

        public string TelefoonNummer { get; set; }

        public string RekeningNummer { get; set; }
    }
}
