using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Managers;

public static class DependencyTrackManager
{
    public static async Task<string> PostSbom(string apiUrl, string sbomJson, string projectName, string apiKey)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

        var formData = new MultipartFormDataContent("----WebKitFormBoundaryqBXTrrykEp3KfEJv");
        formData.Add(new StringContent(projectName), "projectName");
        formData.Add(new StringContent("true"), "autoCreate");
        formData.Add(new StringContent(sbomJson), "bom", $"{projectName}.bom");

        var response = await client.PostAsync(apiUrl, formData);

        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }

    public static void Start(string urlToDockerComposeFile, string adminUrl, int startupTime)
    {
        var dockerComposeFileName = Path.Combine(PowerCommandsConfiguration.AppDataFolderDependencyTrack, "docker-compose.yml");
        if (!File.Exists(dockerComposeFileName))
        {
            var httpClient = new HttpClient();
            var yamlData = httpClient.GetStringAsync(urlToDockerComposeFile).Result;
            File.WriteAllText(dockerComposeFileName, yamlData);
            ConsoleService.Service.WriteSuccessLine(nameof(DependencyTrackManager), "Docker compose file downloaded and save in app directory.");;
        }

        ShellService.Service.Execute("docker-compose", "up -d", PowerCommandsConfiguration.AppDataFolderDependencyTrack);
        ConsoleService.Service.WriteSuccessLine(nameof(DependencyTrackManager), "Dependency Track container starting...");;
        
        PauseService.Pause(startupTime);
        ShellService.Service.OpenWithDefaultProgram(adminUrl, CdCommand.WorkingDirectory);
    }
}