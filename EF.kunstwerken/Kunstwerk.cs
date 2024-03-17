
namespace EF.kunstwerken
{
    public class Kunstwerk
    {
        public string Titel { get; set; } = "";
        public string Artiest { get; set; } = "";
        public string Specs { get; set; } = "";

        public Kunstwerk() { }

        public override string ToString()
        {
            return $"{Artiest} | {Titel}";
        }
    }

}
