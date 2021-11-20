namespace FiveM.Api.Entities
{
    using Perigee.Framework.Base.Entities;

    public class UserLicense : Entity<int>
    {
        public string Type { get; set; }
        public string Owner { get; set; }
        
    }
}
