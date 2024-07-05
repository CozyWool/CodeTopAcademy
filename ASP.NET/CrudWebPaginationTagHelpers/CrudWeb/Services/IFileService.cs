namespace CrudWeb.Services;

public interface IFileService
{
    Task<bool> UploadFile(int id, IFormFile file);
    Task<bool> UploadFile(int id, byte[] content);
}