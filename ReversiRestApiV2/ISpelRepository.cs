using ReversieISpelImplementatie.Model;

namespace ReversiRestApiV2
{
    public interface ISpelRepository
    {
        void AddSpel(Spel spel);

        public List<Spel> GetSpellen();
        public List<Spel> GetSpellenWaiting();
        public Kleur GetBeurtSpelToken(string spelToken);

        Spel GetSpelGameToken(string spelToken);
        Spel GetSpelPlayerToken(string spelerToken);

        List<string> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler();
        void ZetSpel(string spelToken, string spelerToken, ZetJson zet);
    }
}
