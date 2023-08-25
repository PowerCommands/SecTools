using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Managers;

public static class DependencyTrackApiManager
{
    public static async Task<string> PostSbom(string apiUrl, string sbomJson, string projectName, string apiKey)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

        MultipartFormDataContent formData = new MultipartFormDataContent("----WebKitFormBoundaryqBXTrrykEp3KfEJv");
        formData.Add(new StringContent(projectName), "projectName");
        formData.Add(new StringContent("true"), "autoCreate");
        formData.Add(new StringContent(sbomJson), "bom", $"{projectName}.bom");

        var response = await client.PostAsync(apiUrl, formData);

        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;

    }
}