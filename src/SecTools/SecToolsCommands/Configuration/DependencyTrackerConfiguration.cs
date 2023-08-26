namespace SecToolsCommands.Configuration;

public class DependencyTrackerConfiguration
{
    public string UrlToDockerComposeFile { get; set; } = "https://dependencytrack.org/docker-compose.yml";
    public string SbomApiUrl { get; set; } = "http://localhost:8081/api/v1/bom";
    public string AdminUrl { get; set; } = "http://localhost:8080";
    public int StartupTime { get; set; } = 5;
}