using KeycloakExampleWebApi.Infrastructure;
using KeycloakExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakExampleWebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IOpenIdClient openIdClient) : ControllerBase
{
    private string clientId = "top-academy";
    private string clientSecret = "XQ8FcbosYV7NBXXj3CXh2M1D2dJudEbg";

    [HttpGet("keycloak/oids")]
    public async Task<string> GetRedirectUrl([FromQuery] string returnUrl = null)
    {
        return await openIdClient.GetAuthUri(clientId, returnUrl);
    }

    [HttpGet("openid-login")]
    public async Task<string> OpenIdLogin([FromQuery] OpenIdQueryParameters parameters)
    {
        return await openIdClient.GetToken(clientId, clientSecret, parameters.Code, "http://127.0.0.1:5050/auth/openid-login");
    }
}