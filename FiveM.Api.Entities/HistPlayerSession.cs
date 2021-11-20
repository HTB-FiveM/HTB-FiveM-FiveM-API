namespace FiveM.Api.Entities
{
    using System;
    using Perigee.Framework.Base.Entities;

    public class HistPlayerSession : Entity<int>
    {
        public string Identifier { get; set; }
        public int ServerId { get; set; }
        public string SteamHex { get; set; }
        public string SteamName { get; set; }
        public string Discord { get; set; }
        public DateTime ConnectTime { get; set; }
        public DateTime? DisconnectTime { get; set; }
        public string ExitReason { get; set; }


        public User User { get; set; }


    }
}
