namespace FiveM.Api.Contract
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Player")]
    public class PlayerDto
    {
        [DataMember] public string Identifier { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string Skin { get; set; }


    }
}
