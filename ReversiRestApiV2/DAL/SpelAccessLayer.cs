using ReversieISpelImplementatie.Model;

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

        public Spel GetSpelPlayerToken(string spelerToken)
        {
            return new Spel(_spelContext.Spellen.Where(spel => spel.Speler1Token == spelerToken || spel.Speler2Token == spelerToken).FirstOrDefault());
        }

        public void ZetSpel(string spelToken, string spelerToken, ZetJson zet)
        {
            _spelContext.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault().Zet(zet, spelerToken);
            _spelContext.SaveChanges();
        }
    }
}
