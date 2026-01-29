namespace ZiekefondsReizen.ViewModels
{
    public class OpleidingDetailsViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateOnly Begindatum { get; set; }
        public DateOnly Einddatum { get; set; }
        public int AantalPlaatsen { get; set; }

        public Opleiding? OpleidingVereist { get; set; }
    }
}
