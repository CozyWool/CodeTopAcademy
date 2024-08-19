using Microsoft.AspNetCore.Mvc;

namespace KeycloakExampleWebApi.Models;

public class OpenIdQueryParameters
{
    public string State { get; set; }
    [BindProperty(Name = "session_state")]
    public Guid SessionState { get; set; }
    // [BindProperty(Name = "iss")]
    // public string Issuer { get; set; }
    public string Code { get; set; }
}