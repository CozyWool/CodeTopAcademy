using Microsoft.AspNetCore.Mvc;
using ResumeWebApi.models;

namespace ResumeWebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class SkillsController
{
    private readonly List<SkillsModel> _skills =
    [
        new SkillsModel
        {
            ResumeId = 1,
            Skills = ["C#", "Java", "PHP"],
        },
        new SkillsModel
        {
            ResumeId = 2,
            Skills = ["Python", "JavaScript", "HTML & CSS"],
            
        },
    ];

    [HttpGet("{id:int}")]
    public SkillsModel? GetById(int id)
    {
        var model = _skills.FirstOrDefault(m => m.ResumeId == id);
        return model;
    }
}