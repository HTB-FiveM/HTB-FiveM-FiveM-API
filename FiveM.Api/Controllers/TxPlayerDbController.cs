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
    using FiveM.Api.Domain.TxAdmin.Views;
    using FiveM.Api.Domain.Users.Queries;
    using FiveM.Api.Domain.Users.Views;
    using FiveM.Api.Domain.TxAdmin.Queries;

    [ApiController]
    [Route("api/[controller]")]
    public class TxPlayerDbController : Controller
    {
        private readonly IProcessQueries _queries;
        private readonly ILogger<TxPlayerDbController> _logger;

        public TxPlayerDbController(IProcessQueries queries, ILogger<TxPlayerDbController> logger)
        {
            _queries = queries;
            _logger = logger;

        }

        // GET: api/txplayerdb/playtime/{identifier}
        [HttpGet]
        [Route("playtime/{identifier}")]
        public async Task<IActionResult> GetPlayerByIdentifier([FromRoute] string identifier, CancellationToken cancellationToken)
        {
            var playTimeView = await _queries.Execute(new PlayTimeBy { Identifier = identifier }, cancellationToken).ConfigureAwait(false);
            var contract = MapPlayTimeViewToDto.Invoke(playTimeView);

            return Ok(contract);
        }
        

        internal static Func<UserPlayTimeView, UserPlayTimeDto> MapPlayTimeViewToDto => x => new UserPlayTimeDto
        {
            Identifier = x.Identifier,
            PlayTime = x.PlayTime
        };

    }


}
