namespace ZiekefondsReizen.ViewModels
{
    public class OnkostenDeleteViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public float Bedrag { get; set; }
        public DateTime Datum { get; set; }

        public int GroepsreisId { get; set; }
    }
}
