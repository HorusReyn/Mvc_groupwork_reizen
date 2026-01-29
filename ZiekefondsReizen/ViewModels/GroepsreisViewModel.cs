using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace ZiekefondsReizen.ViewModels
{
    public class GroepsreisViewModel
    {
        public int Id { get; set; }
        public DateOnly Begindatum { get; set; }

        public string Bestemming { get; set; }
    }
}
