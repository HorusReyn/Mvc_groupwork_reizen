namespace ZiekefondsReizen.ViewModels
{
    public class BestemmingEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Naam { get; set; }

        public string Beschrijving { get; set; }

        [Required]
        public int MinLeeftijd { get; set; }

        [Required]
        public int MaxLeeftijd { get; set; }
    }
}
