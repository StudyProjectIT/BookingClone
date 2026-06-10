using Amazon.S3;
using Amazon.S3.Model;
using Application.Interfaces;
using Microsoft.Extensions.Options;

namespace Infrastructure.Storage;

public class S3FileStorageService(IOptions<FileStorageOptions> options) : IFileStorageService
{
    private readonly FileStorageOptions _opts = options.Value;

    public async Task<string> SaveAsync(Stream stream, string fileName, string contentType, CancellationToken ct = default)
    {
        using var client = CreateClient();

        var ext = Path.GetExtension(fileName);
        var key = $"hotel-photos/{Guid.NewGuid()}{ext}";

        var request = new PutObjectRequest
        {
            BucketName = _opts.S3.BucketName,
            Key = key,
            InputStream = stream,
            ContentType = contentType,
            DisablePayloadSigning = true
        };

        await client.PutObjectAsync(request, ct);

        var serviceUrl = _opts.S3.ServiceUrl.TrimEnd('/');
        return $"{serviceUrl}/{_opts.S3.BucketName}/{key}";
    }

    public async Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var serviceUrl = _opts.S3.ServiceUrl.TrimEnd('/');
        var prefix = $"{serviceUrl}/{_opts.S3.BucketName}/";
        if (!url.StartsWith(prefix)) return;

        var key = url[prefix.Length..];
        using var client = CreateClient();

        await client.DeleteObjectAsync(_opts.S3.BucketName, key, ct);
    }

    private AmazonS3Client CreateClient()
    {
        var config = new AmazonS3Config
        {
            ServiceURL = _opts.S3.ServiceUrl,
            ForcePathStyle = true
        };
        return new AmazonS3Client(_opts.S3.AccessKey, _opts.S3.SecretKey, config);
    }
}
