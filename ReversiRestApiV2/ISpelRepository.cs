using ReversieISpelImplementatie.Model;
using ReversiRestApiV2.Responses;

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
        void JoinSpel(string spelToken, string spelerToken);
        void LeaveSpel(string spelToken, string spelerToken);
        GameStateResponse GetGameState(string spelToken, string spelerToken);
        void Pass(string spelToken, string spelerToken);
    }
}
