public class OnkostenViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "De titel is verplicht.")]
    public string Titel { get; set; }

    [Required(ErrorMessage = "De omschrijving is verplicht.")]
    public string Omschrijving { get; set; }

    [Required(ErrorMessage = "Het bedrag is verplicht.")]
    [Range(0, double.MaxValue, ErrorMessage = "Het bedrag moet een positief getal zijn.")]
    public float Bedrag { get; set; }

    [Required(ErrorMessage = "De datum is verplicht.")]
    [DataType(DataType.Date)]
    public DateTime Datum { get; set; }

    //public string Foto { get; set; }

    public int GroepsreisId { get; set; }

}
