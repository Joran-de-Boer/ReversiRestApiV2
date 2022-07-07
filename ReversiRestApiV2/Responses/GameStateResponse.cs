namespace ReversiRestApiV2.Responses
{
    public class GameStateResponse
    {
        public bool AanDeBeurt { get; set; }
        public string Bord { get; set; }
        public bool ZetMogelijk { get; set; }
        public bool Afgelopen { get; set; }
        public bool? Gewonnen { get; set; }

    }
}
