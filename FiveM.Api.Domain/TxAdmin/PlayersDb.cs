namespace FiveM.Api.Domain.TxAdmin
{
    using System.Collections.Generic;

    public class TxPlayersDb
    {
        public int Version { get; set; }
        public List<TxPlayer> Players { get; set; }
        public List<TxActions> Actions { get; set; }
        // public TxPendingWl PendingWl { get; set; } // Seems to be unused at present.

    }

    public class TxPlayer
    {
        public string License { get; set; }
        public string Name { get; set; }
        public ulong? PlayTime { get; set; }
        public ulong? TsJoined { get; set; }
        public ulong? TsLastConnection { get; set; }
        public Notes Notes { get; set; }
        
    }

    public class Notes
    {
        public string Text { get; set; }
        public string LastAdmin { get; set; }
        public ulong? TsLastEdit { get; set; }

    }

    public class TxActions
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public string Reason { get; set; }
        public bool Expiration { get; set; }
        public ulong? Timestamp { get; set; }
        public string PlayerName { get; set; }
        public List<string> Identifiers { get; set; }
        public Revocation Revocation { get; set; }
    }

    public class Revocation
    {
        public ulong? Timestamp { get; set; }
        public string Author { get; set; }
    }

}
