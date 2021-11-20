namespace FiveM.Api.Domain.Users.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FiveM.Api.Domain.Users.Views;
    using FiveM.Api.Entities;
    using Microsoft.EntityFrameworkCore;
    using Perigee.Framework.Base.Database;
    using Perigee.Framework.Base.Transactions;

    public class UsersBy : IDefineQuery<IEnumerable<UserView>>
    {
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class HandleUsersByQuery : IHandleQuery<UsersBy, IEnumerable<UserView>>
    {
        private readonly IReadEntities _db;

        public HandleUsersByQuery(IReadEntities db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserView>> Handle(UsersBy query, CancellationToken cancellationToken)
        {
            var usersQuery = _db.Query<User>();

            // If identifier provided then wew only need one
            if (string.IsNullOrWhiteSpace(query.Identifier) == false)
            {
                var theUser = await usersQuery.FirstOrDefaultAsync(u => u.Id == query.Identifier, cancellationToken).ConfigureAwait(false);
                if(theUser == null)
                    return new List<UserView>();

                var ret = new List<User> { theUser };
                return ret.Select(UserView.FuncProjector).ToList();
            }

            // Apply filters
            if (string.IsNullOrWhiteSpace(query.FirstName) == false)
                usersQuery = usersQuery.Where(x => x.FirstName.Contains(query.FirstName));
                
            if (string.IsNullOrWhiteSpace(query.LastName) == false)
                usersQuery = usersQuery.Where(x => x.LastName.Contains(query.LastName));

            // Execute the query and return results
            var users = await usersQuery.Select(UserView.Projector).ToListAsync(cancellationToken).ConfigureAwait(false);

            return users;
        }

    }

}
