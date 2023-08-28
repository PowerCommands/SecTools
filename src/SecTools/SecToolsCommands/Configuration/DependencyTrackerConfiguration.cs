namespace SecToolsCommands.Configuration;

public class DependencyTrackerConfiguration
{
    public string UrlToDockerComposeFile { get; set; } = "https://dependencytrack.org/docker-compose.yml";
    public string SbomApiUrl { get; set; } = "/api/v1/bom";
    public string AdminUrl { get; set; } = "http://localhost:8080";
    public string ApiUrl { get; set; } = "http://localhost:8081";
    public string ApiPorts { get; set; } = "8081:8080";
    public string ApiServerImage { get; set; } = "dependencytrack/apiserver";
    public string ApiServerContainer { get; set; } = "dtrack-frontend";
    public string FrontendImage { get; set; } = "dependencytrack/frontend";
    public string FrontendContainer { get; set; } = "dtrack-apiserver";
    public string FrontendPorts { get; set; } = "8080:8080";
    public int StartupTime { get; set; } = 5;

}