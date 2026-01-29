using ZiekefondsReizen.Models;

namespace ZiekefondsReizen.Models
{
    public class Groepsreis
    {
        public int Id { get; set; }
        public DateOnly Begindatum { get; set; }
        public DateOnly Einddatum { get; set; }
        public float Prijs { get; set; }

        //relaties
        public int BestemmingId { get; set; }
        [JsonIgnore]
        public Bestemming? Bestemming { get; set; } = default!;
        public List<Onkosten>? Onkosten { get; set; } = default!;
        [JsonIgnore]
        public List<Deelnemer>? Deelnemers { get; set; } = default!;
    }
}
