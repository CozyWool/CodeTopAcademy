using Newtonsoft.Json;

namespace KeycloakExampleWebApi.Infrastructure;

public class OpenIdConfigurationResponse
{
    [JsonProperty("issuer")]
    public string Issuer { get; set; }
    [JsonProperty("authorization_endpoint")]
    public string AuthorizationEndpoint { get; set; }
    [JsonProperty("token_endpoint")]
    public string TokenEndpoint { get; set; }
    [JsonProperty("introspection_endpoint")]
    public string IntrospectionEndpoint { get; set; }
    [JsonProperty("userinfo_endpoint")]
    public string UserinfoEndpoint { get; set; }
    [JsonProperty("end_session_endpoint")]
    public string EndSessionEndpoint { get; set; }
}