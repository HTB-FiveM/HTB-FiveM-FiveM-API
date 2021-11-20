namespace FiveM.Api
{
    using FiveM.Api.Domain.Config;
    using Perigee.Framework.Services;

    public class Config
    {
        public DatabaseConfig Database { get; set; }
        public DateTimeConfig DateTime { get; set; }
        public TxAdminConfig TxAdmin { get; set; }
    }


    public interface IDatabaseConfig
    {
        InMemoryConfig InMemory { get; set; }
        string ConnectionString { get; set; }
        string DbmsVersion { get; set; }

    }

    public class DatabaseConfig : IDatabaseConfig
    {
        public InMemoryConfig InMemory { get; set; }
        public string ConnectionString { get; set; }
        public string DbmsVersion { get; set; }

    }

    public class InMemoryConfig
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }

    }
    


}
