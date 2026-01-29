namespace ZiekefondsReizen.ViewModels
{
    public class ActiviteitEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}
