using Domen;

namespace SistemskeOperacije
{
    public class VratiSveMackeSO : OpstaSO
    {
        public List<Macka> Rez { get; private set; }
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new Macka()).OfType<Macka>().ToList();
        }
    }
}
