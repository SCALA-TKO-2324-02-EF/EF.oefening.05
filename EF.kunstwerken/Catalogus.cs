using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.kunstwerken
{
    public class Catalogus
    {
        public List<Kunstwerk> Kunstwerken = new List<Kunstwerk>();

        public void Nieuw(string titel, string artiest, string specs)
        {
            Kunstwerken.Add(new Kunstwerk() { Titel = titel, Artiest = artiest, Specs = specs });
            Sorteer();
        }

        public void Update(Kunstwerk kunstwerk, string titel, string artiest, string specs)
        {
            kunstwerk.Titel = titel;
            kunstwerk.Artiest = artiest;
            kunstwerk.Specs = specs;
            Sorteer();
        }

        public void Verwijder(Kunstwerk kunstwerk)
        {
            Kunstwerken.Remove(kunstwerk);
            Sorteer();
        }

        public void Sorteer()
        {
            Kunstwerken = Kunstwerken.OrderBy(k => k.Titel).ThenBy(k => k.Artiest).ToList();
        }

        public int AantalWerken()
        {
            return Kunstwerken.Count;
        }
    }
}
