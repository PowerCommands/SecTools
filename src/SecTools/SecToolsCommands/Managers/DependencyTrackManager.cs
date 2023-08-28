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
    public static void Start(string apiUrl, string apiServerImage, string apiServerContainer, string apiPorts, string frontendImage, string frontendContainer, string frontendPorts, string adminUrl, int startupTime)
    {
        ShellService.Service.Execute("docker", $"run -d --name {apiServerContainer} -p {apiPorts} {apiServerImage}", "");
        ShellService.Service.Execute("docker", $"run -d --name {frontendContainer} -e API_BASE_URL={apiUrl} -p {frontendPorts} --restart unless-stopped {frontendImage}", "");
        ConsoleService.Service.WriteSuccessLine(nameof(DependencyTrackManager), "Dependency Track container starting...");;
        
        PauseService.Pause(startupTime);
        ShellService.Service.OpenWithDefaultProgram(adminUrl, CdCommand.WorkingDirectory);
    }
}