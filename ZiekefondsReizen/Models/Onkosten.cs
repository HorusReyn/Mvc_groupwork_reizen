namespace ZiekefondsReizen.Models
{
    public class Onkosten
    {
        public int id { get; set; }
        public int groepsreisId {  get; set; }
        public string titel {  get; set; }
        public string omschrijving {  get; set; }
        public float bedrag {  get; set; }
        public DateTime datum { get; set; }
       // public string? foto {  get; set; }
        public Groepsreis? Groepsreis { get; set; }
    }
}
