namespace ReversiRestApiV2.Request
{
    public class ZetSpelRequest
    {
        public string SpelToken { get; set; }
        public string SpelerToken { get; set; }
        public ZetJson Zet { get; set; }
    }
}
