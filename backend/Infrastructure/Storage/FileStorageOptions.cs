namespace Infrastructure.Storage;

public sealed class FileStorageOptions
{
    public string Provider { get; set; } = "Local";
    public string BaseUrl { get; set; } = "";

    public S3Options S3 { get; set; } = new();
}

public sealed class S3Options
{
    public string ServiceUrl { get; set; } = "";
    public string BucketName { get; set; } = "";
    public string AccessKey { get; set; } = "";
    public string SecretKey { get; set; } = "";
}
