namespace ZiekefondsReizen.Models
{
    public class Opleiding
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateOnly Begindatum { get; set; }
        public DateOnly Einddatum { get; set; }
        public int AantalPlaatsen { get; set; }

        //relaties
        public int? OpleidingVereistId { get; set; }
        [JsonIgnore]
        public Opleiding? OpleidingVereist { get; set; } = default!;
    }
}
