namespace ZiekefondsReizen.ViewModels
{
    public class ReviewDetailsViewModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public Bestemming Bestemming { get; set; }
    }
}
