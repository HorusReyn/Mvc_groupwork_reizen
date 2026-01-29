namespace ZiekefondsReizen.ViewModels
{
    public class KindDeleteViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateOnly Geboortedatum { get; set; }
        public string? Allergieen { get; set; }
        public string? Medicatie { get; set; }
    }
}
