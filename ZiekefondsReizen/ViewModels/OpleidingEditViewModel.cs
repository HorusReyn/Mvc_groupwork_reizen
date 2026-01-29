namespace ZiekefondsReizen.ViewModels
{
    public class OpleidingEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Begindatum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Einddatum { get; set; }

        [Required]
        public int AantalPlaatsen { get; set; }

        public int? OpleidingVereistId { get; set; }
        public IEnumerable<SelectListItem> Opleidingen { get; set; } = new List<SelectListItem>();
    }
}
