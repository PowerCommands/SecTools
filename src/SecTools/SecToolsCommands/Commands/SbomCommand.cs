using PainKiller.PowerCommands.Core.Commands;
using SecToolsCommands.Managers;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Create a sbom file in current directory, named directory or git repo",
                         options: "!NAME|upload",
                        useAsync: true,
                         example: "sbom https://github.com/PowerCommands/SecTools.git --name SecTools")]
public class SbomCommand : CommandBase<PowerCommandsConfiguration>
{
    public SbomCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }
    public override async Task<RunResult> RunAsync()
    {
        var path = Input.SingleArgument;
        if (string.IsNullOrEmpty(path)) path = CdCommand.WorkingDirectory;
        var name = GetOptionValue("name");
        
        var jsonData = CycloneDxManager.CreateSbom(path, Configuration.Cdxgen.SbomApiUrl, name, Configuration.Cdxgen.SdxGenServerVolumeMount);

        if (HasOption("upload"))
        {
            var response = await DependencyTrackManager.PostSbom($"{Configuration.DependencyTracker.ApiUrl}{Configuration.DependencyTracker.SbomApiUrl}", jsonData, name, Configuration.Secret.DecryptSecret("##DT_PowerCommand##"));
            if (response.StartsWith("Request failed with status code:")) WriteFailureLine(response);
            else WriteSuccessLine(response);
        }
        return Ok();
    }
}