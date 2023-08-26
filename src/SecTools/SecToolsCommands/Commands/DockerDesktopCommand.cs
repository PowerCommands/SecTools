using SecToolsCommands.Managers;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Start Docker Desktop",
    example: "dockerdesktop")]
public class DockerDesktopCommand : CommandBase<PowerCommandsConfiguration>
{
    public DockerDesktopCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        DockerDesktopManager.StartDockerDesktop(Configuration.DockerDesktop.Path, Configuration.DockerDesktop.StartupTime);
        return Ok();
    }
}