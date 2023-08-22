namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Start Docker Desktop",
    example: "dockerdesktop")]
public class DockerDesktopCommand : CommandBase<PowerCommandsConfiguration>
{
    public DockerDesktopCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var fullFileName = Path.Combine(Configuration.PathToDockerDesktop, "Docker Desktop.exe");
        ShellService.Service.Execute(fullFileName, arguments: "", workingDirectory: "", WriteLine, fileExtension: "");
        WriteSuccessLine("Docker Desktop started");
        return Ok();
    }
}