namespace FiveM.Api.Domain.TxAdmin.Queries
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FiveM.Api.Domain.Config;
    using FiveM.Api.Domain.TxAdmin.Views;
    using Perigee.Framework.Base.Transactions;

    public class PlayTimeBy : IDefineQuery<UserPlayTimeView>
    {
        public string Identifier { get; set; }
    }

    public class GetUserPlayTime : IHandleQuery<PlayTimeBy, UserPlayTimeView>
    {
        private readonly ITxAdminConfig _txAdmin;

        public GetUserPlayTime(ITxAdminConfig txAdmin)
        {
            _txAdmin = txAdmin;
        }

        public Task<UserPlayTimeView> Handle(PlayTimeBy query, CancellationToken cancellationToken)
        {
            if (query == null) throw new ArgumentNullException(nameof(query), "Query definition required");
            if (query.Identifier == null)
                throw new ArgumentNullException(nameof(query.Identifier), "Identifier required");

            // Strip any license: prefix that may have been passed through
            query.Identifier = query.Identifier.Replace("license:", string.Empty);

            var jsonString = File.OpenText(_txAdmin.PlayerDbPath).ReadToEnd();
            var playerDb = Newtonsoft.Json.JsonConvert.DeserializeObject<TxPlayersDb>(jsonString);

            var player = playerDb?.Players.SingleOrDefault(p =>
                string.Compare(query.Identifier, p.License, StringComparison.InvariantCultureIgnoreCase) == 0);

            double playTime = player?.PlayTime ?? 0;

            return Task.FromResult(new UserPlayTimeView
            {
                Identifier = query.Identifier,
                PlayTime = TimeSpan.FromMinutes(playTime)
            });
        }
    }
}
