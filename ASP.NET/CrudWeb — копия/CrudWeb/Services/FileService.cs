using CrudWeb.DataAccess.Repositories;

namespace CrudWeb.Services;

public class FileService : IFileService
{
    private readonly IProductRepository _productRepository;

    public FileService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> UploadFile(int id, IFormFile file)
    {
        try
        {
            if (file.Length <= 0) return false;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytesData = ms.ToArray();
            _productRepository.UpdateImage(id, bytesData);

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("File copy failed", ex);
        }
    }
}