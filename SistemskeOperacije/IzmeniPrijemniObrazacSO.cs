using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniPrijemniObrazacSO : OpstaSO
    {
        private readonly PrijemniObrazac _header;
        private readonly Domen.Dodatno.PrijemniUpdateDTO _cmd;

        public IzmeniPrijemniObrazacSO(PrijemniObrazac p) { _header = p; }
        public IzmeniPrijemniObrazacSO(Domen.Dodatno.PrijemniUpdateDTO cmd) { _cmd = cmd; }

        protected override void Izvrsi()
        {
            if (_cmd != null) { IzvrsiKomande(); return; }
            if (_header != null) { IzmeniHeader(); return; }
            throw new Exception("Nije prosleđen ni header ni komande.");
        }

        private void IzmeniHeader()
        {
            var p = _header;
            var set =
                $"datum='{p.Datum:yyyy-MM-dd}', idRadnik={p.IdRadnik}, idVlasnik={p.IdVlasnik}";
            var rows = repozitorijum.Izmeni(new PrijemniObrazac(), set,
                                            $"idPrijemniObrazac={p.IdPrijemniObrazac}");
            if (rows != 1) throw new Exception("Prijemni obrazac nije izmenjen.");
        }

        private void IzvrsiKomande()
        {
            int id = _cmd.IdPrijemniObrazac;

            // (1) opcioni patch headera
            var setovi = new List<string>();
            if (_cmd.Datum.HasValue) setovi.Add($"datum='{_cmd.Datum:yyyy-MM-dd}'");
            if (_cmd.IdRadnik.HasValue) setovi.Add($"idRadnik={_cmd.IdRadnik.Value}");
            if (_cmd.IdVlasnik.HasValue) setovi.Add($"idVlasnik={_cmd.IdVlasnik.Value}");
            if (setovi.Count > 0)
                repozitorijum.Izmeni(new PrijemniObrazac(), string.Join(", ", setovi),
                                     $"idPrijemniObrazac={id}");

            // (2) brisanja stavki
            if (_cmd.RedniBrojeviZaBrisanje?.Count > 0)
            {
                foreach (var rb in _cmd.RedniBrojeviZaBrisanje.Distinct())
                    repozitorijum.Obrisi(new StavkaObrasca(),
                        $"idPrijemniObrazac={id} AND rb={rb}");

                // reindex (isti princip kao ranije)
                var sve = repozitorijum.Pretrazi(new StavkaObrasca(),
                              $"idPrijemniObrazac={id} ORDER BY rb")
                              .Cast<StavkaObrasca>().ToList();

                for (int i = 0; i < sve.Count; i++)
                {
                    var st = sve[i];
                    int newRb = i + 1;
                    if (st.Rb != newRb)
                    {
                        repozitorijum.Izmeni(new StavkaObrasca(),
                            $"rb={100000 + newRb}",
                            $"idPrijemniObrazac={id} AND rb={st.Rb}");
                    }
                }
                repozitorijum.Izmeni(new StavkaObrasca(), "rb=rb-100000",
                                     $"idPrijemniObrazac={id} AND rb>=100000");
            }

            // (3) dodavanja stavki
            if (_cmd.StavkeZaDodavanje?.Count > 0)
            {
                var postojece = repozitorijum.Pretrazi(new StavkaObrasca(),
                                  $"idPrijemniObrazac={id}")
                                  .Cast<StavkaObrasca>().ToList();
                int next = postojece.Count == 0 ? 1 : postojece.Max(x => x.Rb) + 1;

                foreach (var s in _cmd.StavkeZaDodavanje)
                {
                    s.IdPrijemniObrazac = id;
                    s.Rb = next++;
                    repozitorijum.DodajBezIdentity(s);
                }
            }
        }
    }
}
