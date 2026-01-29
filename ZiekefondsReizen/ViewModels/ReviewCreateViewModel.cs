namespace ZiekefondsReizen.ViewModels
{
    public class ReviewCreateViewModel
    {
        [Required]
        [Range(0,5)]
        public int Score { get; set; }
        [Required]
        public string Text { get; set; }
        public int BestemmingId { get; set; }
        public Bestemming? Bestemming { get; set; }
    }
}
