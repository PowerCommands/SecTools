using System.Net.Http.Json;
using SecToolsCommands.DomainObjects;

namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Show the EPSS score for a given CVE vulnerability.",
                       arguments: "!<CVE>",
                         example: "epss CVE-2022-27225")]
public class EpssCommand : CommandBase<PowerCommandsConfiguration>
{
    public EpssCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        var cve = Input.SingleArgument;
        var url = $"{Configuration.Epss.ApiUrl}{cve}";
        var httpClient = new HttpClient();
        var result = httpClient.GetFromJsonAsync<ExploitPrediction>(url).Result;
        if (result == null || result.data.Length == 0) return Ok($"{url} returned no result");
        WriteCodeExample("EPSS: ",result.data.OrderByDescending(d => d.date).First().GetPercent());
        return Ok();
    }
}