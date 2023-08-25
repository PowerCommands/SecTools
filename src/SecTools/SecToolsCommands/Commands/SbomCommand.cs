using System.Text.Json;
using PainKiller.PowerCommands.Core.Commands;
using SecToolsCommands.DomainObjects;
using SecToolsCommands.Managers;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Create a sbom file in current directory, named directory or git repo",
                         options: "name|upload",
                        useAsync: true,
                         example: "sbom https://github.com/PowerCommands/SecTools.git --name SecTools")]
public class SbomCommand : CommandBase<PowerCommandsConfiguration>
{
    public SbomCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var path = Input.SingleArgument;
        if (string.IsNullOrEmpty(path)) path = CdCommand.WorkingDirectory;
        var url = $"http://127.0.0.1:9090/sbom?path={path}";
        var httpClient = new HttpClient();
        var jsonData = httpClient.GetStringAsync(url).Result;
        WriteLine(jsonData);
        var name = GetOptionValue("name");
        var fileName = Path.Combine(Configuration.SdxGenServerVolumeMount, string.IsNullOrEmpty(name) ? "default.bom" : $"{name}.bom");
        File.WriteAllText(fileName, jsonData);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, };
        var sbom = JsonSerializer.Deserialize<SbomV14>(jsonData, options) ?? new();
        
        WriteCodeExample("sbom.components.length", $"{sbom.components.Length}");

        WriteSuccessLine($"{fileName} saved OK!");

        if (HasOption("upload"))
        {
            var apiUrl = "http://localhost:8081/api/v1/bom";
            DependencyTrackApiManager.PostSbom(apiUrl, jsonData, name, Configuration.Secret.DecryptSecret("##DT_PowerCommand##"));
        }
        return Ok();
    }

    public override async Task<RunResult> RunAsync()
    {
        var path = Input.SingleArgument;
        if (string.IsNullOrEmpty(path)) path = CdCommand.WorkingDirectory;
        var url = $"http://127.0.0.1:9090/sbom?path={path}";
        var httpClient = new HttpClient();
        var jsonData = httpClient.GetStringAsync(url).Result;
        WriteLine(jsonData);
        var name = GetOptionValue("name");
        var fileName = Path.Combine(Configuration.SdxGenServerVolumeMount, string.IsNullOrEmpty(name) ? "default.bom" : $"{name}.bom");
        File.WriteAllText(fileName, jsonData);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, };
        var sbom = JsonSerializer.Deserialize<SbomV14>(jsonData, options) ?? new();
    https://github.com/PowerCommands/PowerCommands2022.git
        WriteCodeExample("sbom.components.length", $"{sbom.components.Length}");

        WriteSuccessLine($"{fileName} saved OK!");

        if (HasOption("upload"))
        {
            var apiUrl = "http://localhost:8081/api/v1/bom";
            var response = await DependencyTrackApiManager.PostSbom(apiUrl, fileName, name, Configuration.Secret.DecryptSecret("##DT_PowerCommand##"));
            if (response.StartsWith("Request failed with status code:")) WriteFailureLine(response);
            else WriteSuccessLine(response);
        }
        return Ok();
    }
}