namespace ZiekefondsReizen.ViewModels
{
    public class KindDetailsViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Geboorte { get; set; }
        public string? Allergieen { get; set; }
        public string? Medicatie { get; set; }
        public List<Deelnemer>? Deelnames { get; set; }
    }
}
