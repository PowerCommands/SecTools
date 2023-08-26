using SecToolsCommands.Managers;

namespace SecToolsCommands.Commands;

[PowerCommandTest(         tests: " ")]
[PowerCommandDesign( description: "Description of your command...",
                         example: "start")]
public class StartCommand : CommandBase<PowerCommandsConfiguration>
{
    public StartCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var fullFileName = Path.Combine(Configuration.DockerDesktop.Path, "Docker Desktop.exe");
        DockerDesktopManager.StartDockerDesktop(fullFileName, Configuration.DockerDesktop.StartupTime);

        var xCfg = Configuration.Cdxgen;
        CycloneDxManager.Start(xCfg.HostMount, xCfg.ContainerMount, xCfg.HostPort, xCfg.ContainerPort, xCfg.SdxGenServerVolumeMount, xCfg.ImageUrl, xCfg.ServerHost);

        DependencyTrackManager.Start(Configuration.DependencyTracker.UrlToDockerComposeFile, Configuration.DependencyTracker.AdminUrl, Configuration.DependencyTracker.StartupTime);
        return Ok();
    }
}