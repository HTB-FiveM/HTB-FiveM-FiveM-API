namespace FiveM.Api.Domain.Users.Views
{
    using System;
    using System.Linq.Expressions;
    using FiveM.Api.Entities;

    public class UserView
    {
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CharacterNumber { get; set; }
        public string Skin { get; set; }

        internal static Expression<Func<User, UserView>> Projector = x => new UserView
        {
            Identifier = x.Identifier,
            FirstName = x.FirstName,
            LastName = x.LastName,
            //CharacterNumber = x.UserLastCharacter.CharId,
            Skin = x.Skin

        };

        internal static Func<User, UserView> FuncProjector = x => new UserView
        {
            Identifier = x.Identifier,
            FirstName = x.FirstName,
            LastName = x.LastName,
            //CharacterNumber = x.UserLastCharacter.CharId,
            Skin = x.Skin

        };

    }
}
