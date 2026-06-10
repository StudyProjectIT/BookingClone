using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Infrastructure.Storage;

public class LocalFileStorageService(IWebHostEnvironment env, IOptions<FileStorageOptions> options) : IFileStorageService
{
    private const string UploadFolder = "uploads";
    private readonly FileStorageOptions _opts = options.Value;

    public async Task<string> SaveAsync(Stream stream, string fileName, string contentType, CancellationToken ct = default)
    {
        var root = string.IsNullOrEmpty(env.WebRootPath) ? env.ContentRootPath : env.WebRootPath;
        var uploadsPath = Path.Combine(root, UploadFolder);
        Directory.CreateDirectory(uploadsPath);

        var ext = Path.GetExtension(fileName);
        var storedName = $"{Guid.NewGuid()}{ext}";
        var filePath = Path.Combine(uploadsPath, storedName);

        await using var fileStream = File.Create(filePath);
        await stream.CopyToAsync(fileStream, ct);

        var baseUrl = _opts.BaseUrl.TrimEnd('/');
        return $"{baseUrl}/{UploadFolder}/{storedName}";
    }

    public Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var fileName = url.Split('/').LastOrDefault();
        if (string.IsNullOrEmpty(fileName)) return Task.CompletedTask;

        var root = string.IsNullOrEmpty(env.WebRootPath) ? env.ContentRootPath : env.WebRootPath;
        var filePath = Path.Combine(root, UploadFolder, fileName);
        if (File.Exists(filePath)) File.Delete(filePath);
        return Task.CompletedTask;
    }
}
