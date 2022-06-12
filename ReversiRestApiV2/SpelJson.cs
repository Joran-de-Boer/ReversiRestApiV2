using ReversieISpelImplementatie.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversiRestApiV2
{
    public class SpelJson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        [Key]
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string? Speler2Token { get; set; }
        public string Bord { get; set; }
        public Kleur AandeBeurt { get; set; }

        public SpelJson()
        {

        }

        public SpelJson(Spel spel)
        {
            Omschrijving = spel.Omschrijving;
            Token = spel.Token;
            Speler1Token = spel.Speler1Token;
            Speler2Token = spel.Speler2Token;
            AandeBeurt = spel.AandeBeurt;
            Bord = BordConverter.ConvertBordToString(spel.Bord);
        }

        public SpelJson(int id, string omschrijving, string token, string speler1Token, string speler2Token, Kleur[,] bord, Kleur aandeBeurt)
        {
            ID = id;
            Omschrijving = omschrijving;
            Token = token;
            Speler1Token = speler1Token;
            Speler2Token = speler2Token;
            Bord = BordConverter.ConvertBordToString(bord);
            AandeBeurt = aandeBeurt;
        }

        public void Zet(ZetJson zet, string spelerToken)
        {
            Spel temp = new Spel(this);
            temp.DoeZet(spelerToken, zet);
            this.Bord = BordConverter.ConvertBordToString(temp.Bord);
        }
    }
}
