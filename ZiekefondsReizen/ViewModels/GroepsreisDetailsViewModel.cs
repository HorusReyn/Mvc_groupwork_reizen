namespace ZiekefondsReizen.ViewModels
{
    public class GroepsreisDetailsViewModel
    {
        public int Id { get; set; }
        public DateOnly Begindatum { get; set; }
        public DateOnly Einddatum { get; set; }
        public float Prijs { get; set; }

        public Bestemming? Bestemming { get; set; }
        public List<Deelnemer>? Deelnemers { get; set; }
    }
}
