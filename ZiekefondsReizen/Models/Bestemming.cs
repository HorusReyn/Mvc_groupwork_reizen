namespace ZiekefondsReizen.Models
{
    public class Bestemming
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int MinLeeftijd {  get; set; }
        public int MaxLeeftijd { get; set; }

        //relaties
        [JsonIgnore]
        public List<Groepsreis>? Groepsreizen { get; set; } = default!;
        [JsonIgnore]
        public List<Review>? Reviews { get; set; } = default!;
    }
}
