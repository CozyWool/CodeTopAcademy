using CrudWeb.DataAccess.Repositories;
using CrudWeb.Messages;
using CrudWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Controllers;

[Route("api/[controller]")]
public class FilesController : Controller
{
    private readonly IFileService _fileService;
    private readonly IProductRepository _productRepository;

    public FilesController(IFileService fileService, IProductRepository productRepository)
    {
        _fileService = fileService;
        _productRepository = productRepository;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetFileByProductId([FromRoute] int id)
    {
        var entity = _productRepository.GetById(id);
        if (entity == null)
            return NotFound();

        if (entity.Image == null)
        {
            return File("~/img/image_not_found.jpg", "image/jpeg");
        }
        
        return File(entity.Image, "image/jpeg");
    }

    [HttpPost("file/{id:int}")]
    public async Task<IActionResult> UploadFile([FromRoute] int id, [FromForm] LoadFileRequest request)
    {
        if (await _fileService.UploadFile(id, request.File))
        {
            return Ok(request);
        }

        return BadRequest();
    }
}