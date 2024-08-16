using System.Text;
using System.Text.Json;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RedisExampleWebApp.DataAccess.Contexts;
using RedisExampleWebApp.DataAccess.Entities;

namespace RedisExampleWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsulController : ControllerBase
{
    private readonly IConsulClient _client;

    public ConsulController(IConsulClient client)
    {
        _client = client;
    }

    [HttpPost("create")]
    public IActionResult CreateKey([FromForm] ConsulRequest request)
    {
        var kvPair = new KVPair(request.Key)
        {
            Value = Encoding.UTF8.GetBytes(request.Value)
        };

        _client.KV.Put(kvPair);
        return Ok();
    }
}

public class ConsulRequest
{
    public string Key { get; set; }
    public string Value { get; set; }
}