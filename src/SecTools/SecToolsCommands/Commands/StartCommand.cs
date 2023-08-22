using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Commands;

[PowerCommandTest(         tests: " ")]
[PowerCommandDesign( description: "Description of your command...",
                         example: "start")]
public class StartCommand : CommandBase<PowerCommandsConfiguration>
{
    public StartCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var fullFileName = Path.Combine(Configuration.PathToDockerDesktop, "Docker Desktop.exe");
        ShellService.Service.Execute(fullFileName, arguments: "", workingDirectory: "", WriteLine, fileExtension: "");
        WriteSuccessLine("Docker Desktop started");

        ShellService.Service.Execute("docker", $"run --rm -v /tmp:/tmp -p 9090:9090 -v {Configuration.SdxGenServerVolumeMount}:/app:rw -t ghcr.io/cyclonedx/cdxgen -r /app --server --server-host 0.0.0.0", CdCommand.WorkingDirectory);
        WriteSuccessLine("CycloneDX Generator server started");

        var dockerComposeFileName = Path.Combine(AppContext.BaseDirectory, "docker-compose.yml");
        if (!File.Exists(dockerComposeFileName))
        {
            var url = Configuration.UrlToDockerComposeFile;
            var httpClient = new HttpClient();
            var yamlData = httpClient.GetStringAsync(url).Result;

            File.WriteAllText(dockerComposeFileName, yamlData);
            WriteSuccessLine("Docker compose file downloaded and save in app directory.");
        }

        ShellService.Service.Execute("docker-compose", "up -d", CdCommand.WorkingDirectory);
        WriteSuccessLine("Dependency Track container started");

        return Ok();
    }
}