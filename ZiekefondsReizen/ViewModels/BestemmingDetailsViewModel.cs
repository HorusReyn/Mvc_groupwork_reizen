namespace ZiekefondsReizen.ViewModels
{
    public class BestemmingDetailsViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int MinLeeftijd { get; set; }
        public int MaxLeeftijd { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
