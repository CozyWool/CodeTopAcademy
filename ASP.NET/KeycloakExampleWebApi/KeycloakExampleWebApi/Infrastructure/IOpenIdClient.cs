namespace KeycloakExampleWebApi.Infrastructure;

public interface IOpenIdClient
{
    Task<string> GetAuthUri(string clientId, string redirectUri = null);

    Task<string> GetToken(string clientId,
        string clientSecret,
        string authorizationCode,
        string redirectUri = null);
}