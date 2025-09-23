using Domen;

namespace SistemskeOperacije
{
    public class VratiSviMackaSO : OpstaSO
    {
        public List<Macka> Rez {  get; set; }
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new Macka()).OfType<Macka>().ToList();
        }
    }
}
