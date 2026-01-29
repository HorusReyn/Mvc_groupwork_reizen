namespace ZiekefondsReizen.ViewModels
{
    public class KindCreateViewModel
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Geboortedatum { get; set; }

        public string? Allergieen { get; set; }
        public string? Medicatie { get; set; }

    }
}
