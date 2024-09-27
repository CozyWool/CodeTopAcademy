using Microsoft.AspNetCore.Mvc;
using ResumeWebApi.models;

namespace ResumeWebApi.Controllers;

[Route("professional-experience")]
[ApiController]
public class ProfessionalExperienceController
{
    private readonly List<ProfessionalExperienceModel> _professionalExperiences =
    [
        new ProfessionalExperienceModel
        {
            ResumeId = 1,
            ProfessionalExperience = "5 years in Enterprise"
        },
        new ProfessionalExperienceModel
        {
            ResumeId = 2,
            ProfessionalExperience = "Junior developer, 1 year"
        },
    ];

    [HttpGet("{id:int}")]
    public ProfessionalExperienceModel? GetById(int id)
    {
        var model = _professionalExperiences.FirstOrDefault(m => m.ResumeId == id);
        return model;
    }
}