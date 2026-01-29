namespace ZiekefondsReizen.Models
{
    public class Kind
    {
        //public string PersoonId { get; set; }
        public int Id { get; set; }
        public string Naam {  get; set; }
        public string Voornaam {  get; set; }
        public DateOnly Geboortedatum { get; set; }
        public string? Allergieen {  get; set; }
        public string?  Medicatie {  get; set; }

        [JsonIgnore]
        public List<Deelnemer>? Deelnames { get; set; }

    }
}
