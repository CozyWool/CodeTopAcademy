using Microsoft.AspNetCore.Mvc;
using ResumeWebApi.models;

namespace ResumeWebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ResumeController
{
    private readonly List<ResumeModel> _resumes =
    [
        new ResumeModel
        {
            Id = 1,
            Name = "Petr",
            Surname = "Petrov",
        },
        new ResumeModel
        {
            Id = 2,
            Name = "Ivan",
            Surname = "Ivanov",
        },
    ];

    [HttpGet("{id:int}")]
    public ResumeModel? GetById(int id)
    {
        var resume = _resumes.FirstOrDefault(model => model.Id == id);
        return resume;
    }
}