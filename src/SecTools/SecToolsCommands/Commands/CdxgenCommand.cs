using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Run cdxgen commands",
                         example: "cdxgen")]
public class CdxgenCommand : CommandBase<PowerCommandsConfiguration>
{
    public CdxgenCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        ShellService.Service.Execute("docker", $"run --rm -v /tmp:/tmp -p 9090:9090 -v {Configuration.SdxGenServerVolumeMount}:/app:rw -t ghcr.io/cyclonedx/cdxgen -r /app --server --server-host 0.0.0.0", CdCommand.WorkingDirectory);
        return Ok();
    }
}