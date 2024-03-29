﻿using ReversieISpelImplementatie.Model;
using ReversiRestApiV2.Responses;

namespace ReversiRestApiV2
{
    public class SpelRepository : ISpelRepository
    {
        // Lijst met tijdelijke spellen
        public List<Spel> Spellen { get; set; }

        public SpelRepository()
        {
            Spel spel1 = new Spel();
            Spel spel2 = new Spel();
            Spel spel3 = new Spel();

            spel1.Speler1Token = "abcdef";
            spel1.Omschrijving = "Potje snel reveri, dus niet lang nadenken";
            spel2.Speler1Token = "ghijkl";
            spel2.Speler2Token = "mnopqr";
            spel2.Omschrijving = "Ik zoek een gevorderde tegenspeler!";
            spel3.Speler1Token = "stuvwx";
            spel3.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";


            Spellen = new List<Spel> { spel1, spel2, spel3 };
        }

        public void AddSpel(Spel spel)
        {
            Spellen.Add(spel);
        }

        public List<Spel> GetSpellen()
        {
            return Spellen;
        }

        public Spel GetSpelGameToken(string spelToken)
        {
            return Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault();
        }

        public Spel GetSpelPlayerToken(string spelerToken)
        {
            return Spellen.Where(spel => spel.Speler1Token == spelerToken || spel.Speler2Token == spelerToken).FirstOrDefault();
        }

        public List<string> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return Spellen
                .Where(spel => spel.Speler2Token == null)
                .Select(spel => spel.Omschrijving).ToList();
        }

        public List<Spel> GetSpellenWaiting()
        {
            return Spellen.Where(spel => spel.Speler2Token == null).ToList();
        }

        public Kleur GetBeurtSpelToken(string spelToken)
        {
            return Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault().AandeBeurt;
        }

        public void ZetSpel(string spelToken, string spelerToken, ZetJson zet)
        {
            Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault().DoeZet(spelerToken, zet);
        }

        public void JoinSpel(string spelToken, string spelerToken)
        {
            throw new NotImplementedException();
        }

        public void LeaveSpel(string spelToken, string spelerToken)
        {
            throw new NotImplementedException();
        }

        public void GetGameState(string spelToken, string spelerToken)
        {
            throw new NotImplementedException();
        }

        GameStateResponse ISpelRepository.GetGameState(string spelToken, string spelerToken)
        {
            throw new NotImplementedException();
        }

        public void Pass(string spelToken, string spelerToken)
        {
            throw new NotImplementedException();
        }

        public void Delete(string spelToken)
        {
            throw new NotImplementedException();
        }
    }
}
