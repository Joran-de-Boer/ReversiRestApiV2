using Microsoft.AspNetCore.Mvc;
using ReversieISpelImplementatie.Model;
using ReversiRestApiV2.Request;
using ReversiRestApiV2.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReversiRestApiV2.Controllers
{
    [Route("api/Spel")]
    [ApiController]
    public class SpelController : ControllerBase
    {
        private readonly ISpelRepository iRepository;

        public SpelController(ISpelRepository repository)
        {
            iRepository = repository;
        }


        // GET api/spel
        [HttpGet]
        public ActionResult<IEnumerable<SpelJson>> GetSpellenWaiting()
        {
            return iRepository.GetSpellenWaiting().Select(s => new SpelJson(s)).ToList();
        }

        [HttpGet("Description/Waiting")]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler() => iRepository.GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler();

        [HttpGet("Gametoken/{token}")]
        public ActionResult<SpelJson> GetSpelGameToken(string token)
        {
            Spel spel = iRepository.GetSpelGameToken(token);
            if (spel == null)
            {
                return NotFound();
            }
            return new SpelJson(spel);
        }

        [HttpGet("Playertoken/{token}")]
        public ActionResult<SpelJson> GetSpelPlayerToken(string token)
        {
            Spel spel = iRepository.GetSpelPlayerToken(token);
            if (spel == null)
            {
                return NotFound();
            }
            return new SpelJson(spel);
        }

        [HttpGet("Beurt/{token}")]
        public ActionResult<Kleur> GetBeurtSpelToken(string token)
        {
            return iRepository.GetBeurtSpelToken(token);
        }

        [HttpPost("New")]
        public void PostNewSpel([FromBody] NewSpelRequest request)
        {
            Spel spel = new Spel()
            {
                Speler1Token = request.SpelerToken,
                Omschrijving = request.Omschrijving
            };
            iRepository.AddSpel(spel);
        }

        [HttpPut("Join")]
        public void JoinSpel([FromBody] JoinSpelRequest request)
        {
            iRepository.JoinSpel(request.SpelId, request.SpelerId);
        }

        [HttpPut("Zet")]
        public void PutZetSpel([FromBody] ZetSpelRequest request)
        {
            iRepository.ZetSpel(request.SpelToken, request.SpelerToken, request.Zet);
        }

        [HttpPost("Gamestate")]
        public ActionResult<GameStateResponse> GetGameState([FromBody] GameStateRequest request)
        {
            return iRepository.GetGameState(request.SpelToken, request.SpelerToken);
        }

        [HttpPut("Pass")]
        public void Pass([FromBody] PassRequest request)
        {
            iRepository.Pass(request.spelToken, request.spelerToken);
        }

        // ...

    }
}
