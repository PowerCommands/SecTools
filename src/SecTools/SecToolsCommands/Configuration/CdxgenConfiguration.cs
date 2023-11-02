namespace SecToolsCommands.Configuration;

public class CdxgenConfiguration
{
    public string SdxGenServerVolumeMount { get; set; } = "";
    public string ImageUrl { get; set; } = "ghcr.io/cyclonedx/cdxgen:v8.6.0";
    public string HostPort { get; set; } = "9090";
    public string ContainerPort { get; set; } = "9090";
    public string HostMount { get; set; } = "/tmp";
    public string ContainerMount { get; set; } = "/tmp";
    public string ServerHost { get; set; } = "0.0.0.0";
    public string SbomApiUrl { get; set; } = "http://127.0.0.1:9090/sbom";
    public bool ResolveLicenses { get; set; }
}