using System.Text;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace MinioWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class S3Controller : ControllerBase
{
    private readonly IMinioClient _minioClient;

    public S3Controller(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    [HttpGet("{bucketId}/{file}")]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUrl(string bucketId, string file)
    {
        var args = new PresignedGetObjectArgs()
            .WithBucket(bucketId)
            .WithObject(file)
            .WithExpiry(60 * 60 * 24);
        return Ok(await _minioClient.PresignedGetObjectAsync(args));
    }

    [HttpGet]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListBuckets()
    {
        var sb = new StringBuilder();
        var listBuckets = await _minioClient.ListBucketsAsync();
        foreach (var bucket in listBuckets.Buckets)
        {
            sb.AppendLine($"{bucket.Name} {bucket.CreationDateDateTime}");
        }

        return Ok(sb.ToString());
    }

    [HttpPost]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFile()
    {
        try
        {
            const string bucketName = "top-academy-bucket";
            const string objectName = "appsettings.Development.json";
            const string filePath =
                @"C:\Repos\CodeTopAcademy\ASP.NET\MinioWebApplication\MinioWebApplication\Download\appsettings.Development.json";
            const string contentType = "application/zip";

            var args = new BucketExistsArgs().WithBucket(bucketName);
            var found = await _minioClient.BucketExistsAsync(args);
            if (!found)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }

            var putArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithFileName(filePath)
                .WithContentType(contentType);
            await _minioClient.PutObjectAsync(putArgs);
            return Ok(objectName);
        }
        catch (MinioException ex)
        {
            return Problem("File upload error: {0}", title: ex.Message, statusCode: 500);
        }
    }
}