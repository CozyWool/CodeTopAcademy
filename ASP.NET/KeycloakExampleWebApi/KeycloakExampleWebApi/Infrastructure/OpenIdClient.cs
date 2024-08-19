using System.Text;
using System.Web;
using KeycloakExampleWebApi.Converters;
using KeycloakExampleWebApi.Models;
using Newtonsoft.Json;

namespace KeycloakExampleWebApi.Infrastructure;

public class OpenIdClient(string wellKnownUri) : IOpenIdClient
{
    public async Task<string> GetAuthUri(string clientId, string redirectUri = null)
    {
        var configuration = await GetConfiguration(wellKnownUri);
        var sb = new StringBuilder($"{configuration.AuthorizationEndpoint}?");
        sb.Append($"client_id={clientId}");
        sb.Append("&response_type=code");
        if (!string.IsNullOrEmpty(redirectUri))
        {
            sb.Append($"&redirect_uri={HttpUtility.UrlEncode(redirectUri)}");
        }

        var state = DateToUriBase64Converter.Encode(DateTimeOffset.Now);
        sb.Append($"&state={state}");
        return sb.ToString();
    }

    public async Task<string> GetToken(string clientId, string clientSecret, string authorizationCode,
        string redirectUri = null)
    {
        var configuration = await GetConfiguration(wellKnownUri);
        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, configuration.TokenEndpoint);
        var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
        request.Headers.Add("Authorization", $"Basic {encoded}");
        var collection = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "authorization_code"),
            new("code", authorizationCode)
        };

        if (!string.IsNullOrEmpty(redirectUri))
        {
            collection.Add(new KeyValuePair<string, string>("redirect_uri", redirectUri));
        }

        request.Content = new FormUrlEncodedContent(collection);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var tokenResult =
            JsonConvert.DeserializeObject<OpenIdTokenResponse>(await response.Content.ReadAsStringAsync());
        return tokenResult.AccessToken;
    }

    private static async Task<OpenIdConfigurationResponse> GetConfiguration(string wellKnownUri)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, wellKnownUri);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<OpenIdConfigurationResponse>(await response.Content.ReadAsStringAsync());
    }
}