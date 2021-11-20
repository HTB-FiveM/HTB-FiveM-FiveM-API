namespace FiveM.Api.Domain.Config
{
    public interface ITxAdminConfig
    {
        string PlayerDbPath { get; set; }
    }

    public class TxAdminConfig : ITxAdminConfig
    {
        public string PlayerDbPath { get; set; }
    }
}
