using PainKiller.PowerCommands.Core.Commands;
using SecToolsCommands.Managers;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Pull necessary docker images.",
                         options: "docker|dt-key",
                         example: "setup")]
public class SetupCommand : CommandBase<PowerCommandsConfiguration>
{
    public SetupCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        if (HasOption("docker"))
        {
            DockerDesktopManager.StartDockerDesktop(Configuration.DockerDesktop.Path, Configuration.DockerDesktop.StartupTime);

            DockerDesktopManager.Pull(Configuration.Cdxgen.ImageUrl);
            WriteSuccessLine("\nCdxgen setup done!");

            DockerDesktopManager.Pull(Configuration.DependencyTracker.ApiServerImage);
            DockerDesktopManager.Pull(Configuration.DependencyTracker.FrontendImage);
        
            WriteSuccessLine("\nDependency track setup done!");
            return Ok();
        }
        else if (HasOption("dt-key"))
        {
            var secretCommand = new SecretCommand("secret", Configuration);
            secretCommand.InitializeAndValidateInput("secret --create \"DT_PowerCommand\"".Interpret());
            secretCommand.Run();
            return Ok();
        }
        WriteWarning("No option was provided, you need to provide either --docker to setup the docker images or --dt_key to setup the Dependency Track access token. (create a Team in DT Administration/Access management/Teams)");
        return Ok();
    }
}