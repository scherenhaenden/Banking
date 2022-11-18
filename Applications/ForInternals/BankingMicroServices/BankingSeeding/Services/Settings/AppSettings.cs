namespace BankingSeeding.Services.Settings;

public class AppSettings
{
    public List<DBContext> DBContexts { get; set; }
}

public class DBContext
{
    public string Name { get; set; }
    public string ConnectionString { get; set; }
    public string ProviderName { get; set; }
    public string ContextName { get; set; }
}

public class Root
{
    public AppSettings appSettings { get; set; }
}