namespace SecToolsCommands.Managers;
public static class CycloneDxManager
{
    public static void Start(string hostMount, string containerMount, string hostPort, string containerPort, string sdxGenServerVolumeMount, string imageUrl, string serverHost)
    {
        var arguments = $"run --rm -v {hostMount}:{containerMount} -p {hostPort}:{containerPort} -v {sdxGenServerVolumeMount}:/app:rw -t {imageUrl} -r /app --server --server-host {serverHost}";
        ShellService.Service.Execute("docker", arguments, "");
        ConsoleService.Service.WriteSuccessLine(nameof(CycloneDxManager), "CycloneDX Generator server ready!");
    }
    public static string CreateSbom(string path, string sbomApiUrl, string name, string sdxGenServerVolumeMount)
    {
        var url = $"{sbomApiUrl}?path={path}";
        var httpClient = new HttpClient();
        var jsonData = httpClient.GetStringAsync(url).Result;
        Console.WriteLine(jsonData);
        var fileName = Path.Combine(sdxGenServerVolumeMount, string.IsNullOrEmpty(name) ? "default.bom" : $"{name}.bom");
        File.WriteAllText(fileName, jsonData);
        ConsoleService.Service.WriteSuccessLine(nameof(CycloneDxManager), $"{fileName} saved OK!");
        return jsonData;
    }
}