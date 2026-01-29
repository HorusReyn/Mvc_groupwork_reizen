namespace ZiekefondsReizen.ViewModels
{
    public class GroepsreisCreateViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Begindatum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Einddatum { get; set; }

        [Required]
        public float Prijs { get; set; }

        public int BestemmingId { get; set; }
        public List<SelectListItem> Bestemmingen { get; set; } = new List<SelectListItem>();
    }
}
