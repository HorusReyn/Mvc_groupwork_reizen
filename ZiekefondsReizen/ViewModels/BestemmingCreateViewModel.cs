namespace ZiekefondsReizen.ViewModels
{
    public class BestemmingCreateViewModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public int MinLeeftijd { get; set; }
        [Required]
        public int MaxLeeftijd { get; set; }
    }
}
