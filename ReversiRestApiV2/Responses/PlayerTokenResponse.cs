using ReversieISpelImplementatie.Model;

namespace ReversiRestApiV2.Responses
{
    public class PlayerTokenResponse
    {
        public string Bord { get; set; }
        public Kleur AanDeBeurt { get; set; }
        public PlayerTokenResponse(SpelJson spel)
        {
            Bord = spel.Bord;
            AanDeBeurt = spel.AandeBeurt;
        }
    }
}
