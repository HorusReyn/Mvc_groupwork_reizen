namespace ZiekefondsReizen.Models
{
    public class Deelnemer
    {
        public int Id { get; set; }
        public int KindId { get; set; }
        public int GroepsreisId { get; set; }
        public string? Opmerkingen { get; set; }

        public Groepsreis Groepsreis { get; set; }
        public Kind Kind { get; set; }
    }
}
