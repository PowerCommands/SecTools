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

        var dCfg = Configuration.DependencyTracker;
        DependencyTrackManager.Start(dCfg.ApiUrl, dCfg.ApiServerImage, dCfg.ApiServerContainer, dCfg.ApiPorts, dCfg.FrontendImage, dCfg.FrontendContainer, dCfg.FrontendPorts, dCfg.AdminUrl, dCfg.StartupTime);

        WriteHeadLine("You are now ready to create SBOM files\n");
        WriteLine("Notice that to automatically upload the SBOM to Dependency Track, you first need to do two things:");
        WriteLine("1) Create a Team in Dependency Track give the Team BOM_UPLOAD, PROJECT_CREATION");
        WriteLine("2) Copy the API key, and create a secret in PowerCommands like this:");
        WriteCodeExample("secret","--create \"DT_PowerCommand\"");

        WriteLine("\nNow you can upload your sbom after it has been created with the sbom command like this:");
        WriteCodeExample("sbom","https://github.com/PowerCommands/PowerCommands2022.git --name exampleRepo --upload");

        return Ok();
    }
}