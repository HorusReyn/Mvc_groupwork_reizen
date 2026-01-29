namespace ZiekefondsReizen.ViewModels
{
    public class DeelnemerViewModel
    {
        public int GroepsreisId { get; set; }

        public string? Opmerking { get; set; }

        [Required]
        public int KindId { get; set; }


        public List<SelectListItem> Kinderen { get; set; } = new List<SelectListItem>();
        //public List<SelectListItem> Groepsreizen { get; set; } = new List<SelectListItem>();
    }
}
