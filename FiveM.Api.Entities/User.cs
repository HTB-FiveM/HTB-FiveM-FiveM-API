namespace FiveM.Api.Entities
{
    using System.Collections.Generic;
    using Perigee.Framework.Base.Entities;

    public class User : Entity<string>
    {
    public string Identifier
    {
        get => Id;
        set => Id = value;
    }

    public string Accounts { get; set; }
    public string Group { get; set; }
    public string Inventory { get; set; }
    public string Job { get; set; }
    public int JobGrade { get; set; }
    public string Loadout { get; set; }
    public string Position { get; set; }
    public string Skin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public char? Sex { get; set; }
    public int Height { get; set; }
    public string LastProperty { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsDead { get; set; }
    public string Tattoos { get; set; }
    public int JailTime { get; set; }


    public IEnumerable<HistPlayerSession> Sessions { get; set; }



    }
}
