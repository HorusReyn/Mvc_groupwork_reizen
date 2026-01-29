using System.ComponentModel.DataAnnotations;

namespace ZiekefondsReizen.ViewModels
{
    public class OnkostenCreateViewModel
    {
        [Required(ErrorMessage = "Titel is verplicht")]
        public string Titel { get; set; }

        [Required]
        public int GroepsreisID {  get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht")]
        public string Omschrijving { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Bedrag moet groter zijn dan 0")]
        public decimal Bedrag { get; set; }

        [Required(ErrorMessage = "Datum is verplicht")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

    }

}
