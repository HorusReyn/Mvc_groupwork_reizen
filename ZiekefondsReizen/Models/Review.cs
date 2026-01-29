namespace ZiekefondsReizen.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }

        //relaties
        public int BestemmingId { get; set; }
        [JsonIgnore]
        public Bestemming Bestemming { get; set; } = default!;
    }
}
