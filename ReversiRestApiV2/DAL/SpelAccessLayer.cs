using ReversieISpelImplementatie.Model;
using ReversiRestApiV2.Responses;

namespace ReversiRestApiV2.DAL
{
    public class SpelAccessLayer : ISpelRepository
    {
        protected SpelContext _spelContext;
        public SpelAccessLayer(SpelContext spelContext)
        {
            _spelContext = spelContext;
        }

        public void AddSpel(Spel spel)
        {
            _spelContext.Spellen.Add(new SpelJson(spel));
            _spelContext.SaveChanges();
        }

        public Kleur GetBeurtSpelToken(string spelToken)
        {
            return _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault().AandeBeurt;
        }

        public Spel GetSpelGameToken(string spelToken)
        {
            return new Spel(_spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault());
        }

        public List<Spel> GetSpellen()
        {
            try
            {
                var toRemove = _spelContext.Spellen.Where(spel => spel.Speler1Token == null && spel.Speler2Token == null);
                foreach (var item in toRemove)
                {
                    _spelContext.Spellen.Remove(item);
                }
                _spelContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return _spelContext.Spellen.Select(spel => new Spel(spel)).ToList();
        }

        public List<Spel> GetSpellenWaiting()
        {
            return GetSpellen().Where(spel => spel.Speler2Token == null).ToList();
        }

        public List<string> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return GetSpellenWaiting().Select(spel => spel.Omschrijving).ToList();
        }

        public Spel? GetSpelPlayerToken(string spelerToken)
        {
            SpelJson? spel = _spelContext.Spellen.Where(spel => spel.Speler1Token == spelerToken || spel.Speler2Token == spelerToken).FirstOrDefault();
            if (spel != null)
            {
                return new Spel(_spelContext.Spellen.Where(spel => spel.Speler1Token == spelerToken || spel.Speler2Token == spelerToken).FirstOrDefault());
            }
            return null;
        }

        public void ZetSpel(string spelToken, string spelerToken, ZetJson zet)
        {
            _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault()?.Zet(zet, spelerToken);
            _spelContext.SaveChanges();
        }

        public void JoinSpel(string speltoken, string spelertoken)
        {
            _spelContext.Spellen.Where(spel => spel.Token == speltoken).FirstOrDefault().Speler2Token = spelertoken;
            _spelContext.SaveChanges();
        }

        public void LeaveSpel(string spelToken, string spelerToken)
        {
            SpelJson? spel = _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault();
            if(spel != null)
            {
                if(spel.Speler1Token == spelerToken)
                {
                    spel.Speler1Token = null;
                }
                if(spel.Speler2Token == spelerToken)
                {
                    spel.Speler2Token= null;
                }
            }
            _spelContext.SaveChanges();
        }

        public GameStateResponse? GetGameState(string spelToken, string spelerToken)
        {
            GameStateResponse? response = null;
            SpelJson? spel = _spelContext.Spellen.Where(spel => spel.Token == spelToken && (spel.Speler1Token == spelerToken || spel.Speler2Token == spelerToken)).FirstOrDefault();
            if(spel != null)
            {
                Spel spelLogica = new Spel(spel);
                bool afgelopen = spelLogica.Afgelopen();
                bool? gewonnen = false;
                if (afgelopen) {
                    gewonnen = spel.IsPlayerColor(spelLogica.OverwegendeKleur(), spelerToken);
                }


                response = new GameStateResponse()
                {
                    AanDeBeurt = spel.IsAanDeBeurt(spelerToken),
                    Afgelopen = afgelopen,
                    Gewonnen = gewonnen,
                    Bord = spel.Bord,
                    ZetMogelijk = spelLogica.IsErEenZetMogelijk(spel.GetPlayerColor(spelerToken))
                };
            }
            return response;
        }

        public void Pass(string spelToken, string spelerToken)
        {
            SpelJson? spel = _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault();
            if (spel != null)
            {
                Spel spelLogica = new Spel(spel);
                if (spel.IsAanDeBeurt(spelerToken))
                {
                    spelLogica.Pas();
                    spel.AandeBeurt = spelLogica.AandeBeurt;
                }
            }
            _spelContext.SaveChanges();          
        }

        public void Delete(string spelToken)
        {
            SpelJson? spel = _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault();
            if (spel != null)
            {
                _spelContext.Spellen.Remove(spel);
            }
        }
    }
}
