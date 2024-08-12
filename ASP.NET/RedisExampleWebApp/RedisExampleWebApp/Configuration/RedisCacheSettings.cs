using Microsoft.Extensions.Options;

namespace RedisExampleWebApp.Configuration;

public class RedisCacheSettings
{
    public const string ConfigurationKey = "RedisCacheSettings";
    public string Configuration { get; set; }
    public string InstanceName { get; set; }
}