namespace ReversiRestApiV2
{
    public class ZetJson
    {
        public int RijZet { get; set; }
        public int KolomZet { get; set; }

        public ZetJson(int rijZet, int kolomZet)
        {
            RijZet = rijZet;
            KolomZet = kolomZet;
        }
    }
}
