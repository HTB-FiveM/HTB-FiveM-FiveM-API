namespace FiveM.Api.Domain.TxAdmin.Views
{
    using System;

    public class UserPlayTimeView
    {
        public string Identifier { get; set; }
        public TimeSpan PlayTime { get; set; }

    }
}
