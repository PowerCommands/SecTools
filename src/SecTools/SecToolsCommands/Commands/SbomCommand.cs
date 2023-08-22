using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Create a sbom file in current directory, named directory or git repo",
                         options: "path",
                         example: "sbom")]
public class SbomCommand : CommandBase<PowerCommandsConfiguration>
{
    public SbomCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var path = GetOptionValue("path");
        if (string.IsNullOrEmpty(path)) path = CdCommand.WorkingDirectory;
        var url = $"http://127.0.0.1:9090/sbom?path={path}";
        var httpClient = new HttpClient();
        var jsonData = httpClient.GetStringAsync(url).Result;
        WriteLine(jsonData);
        return Ok();
    }
}