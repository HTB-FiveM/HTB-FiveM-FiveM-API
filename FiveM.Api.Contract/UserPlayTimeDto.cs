namespace FiveM.Api.Contract
{
    using System;

    public class UserPlayTimeDto
    {
        public string Identifier { get; set; }
        public TimeSpan PlayTime { get; set; }

    }
}
