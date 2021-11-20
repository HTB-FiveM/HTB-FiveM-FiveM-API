namespace FiveM.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Perigee.Framework.Base.Transactions;
    using FiveM.Api.Contract;
    using FiveM.Api.Domain.Users.Queries;
    using FiveM.Api.Domain.Users.Views;


    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IProcessQueries _queries;
        private readonly IProcessCommands _commands;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IProcessQueries queries, IProcessCommands commands, ILogger<PlayerController> logger)
        {
            _queries = queries;
            _commands = commands;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers(CancellationToken cancellationToken)
        {
            var players = await _queries.Execute(new UsersBy(), cancellationToken).ConfigureAwait(false);
            var contract = players.Select(MapUserToPlayer).ToList();

            return Ok(contract);
        }

        // GET: api/player/{identifier}
        [HttpGet]
        [Route("{identifier}")]
        public async Task<IActionResult> GetPlayerByIdentifier([FromRoute] string identifier, CancellationToken cancellationToken)
        {
            var players = await _queries.Execute(new UsersBy { Identifier = identifier }, cancellationToken).ConfigureAwait(false);
            var contract = players.Select(MapUserToPlayer).ToList();

            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> SearchForPlayer([FromBody] UsersBy query, CancellationToken cancellationToken)
        {
            var players = await _queries.Execute(query, cancellationToken).ConfigureAwait(false);
            var contract = players.Select(MapUserToPlayer).ToList();

            return Ok(contract);
        }

        internal static Func<UserView, PlayerDto> MapUserToPlayer => x => new PlayerDto
        {
            Identifier = x.Identifier,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Skin = x.Skin
        };

    }


}
