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


        //using var client = new HttpClient();
        //client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //using var content = new MultipartFormDataContent("----WebKitFormBoundaryqBXTrrykEp3KfEJv");
        //content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data; boundary=----WebKitFormBoundaryqBXTrrykEp3KfEJv");

        //content.Add(new StringContent(projectName), "projectName");
        //content.Add(new StringContent("autoCreate"), "true");
        //content.Add(new StreamContent(File.OpenRead(fileName)), "bom", Path.GetFileName(fileName));

        //var response = await client.PostAsync(apiUrl, content);
        //return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : $"Request failed with status code: {response.StatusCode}";

        //string content = $@"-X POST http://localhost:8081/api/v1/bom ^
        //    -H ""X-Api-Key: {apiKey}"" ^
        //    -H ""Content-Type: multipart/form-data; boundary=----WebKitFormBoundaryqBXTrrykEp3KfEJv"" ^
        //    --data-binary @- ^
        //    $'------WebKitFormBoundaryqBXTrrykEp3KfEJv\r\n' ^
        //    'Content-Disposition: form-data; name=""projectName""\r\n' ^
        //    '\r\n{projectName}\r\n' ^
        //    '------WebKitFormBoundaryqBXTrrykEp3KfEJv\r\n' ^
        //    'Content-Disposition: form-data; name=""autoCreate""\r\n' ^
        //    '\r\ntrue\r\n' ^
        //    '------WebKitFormBoundaryqBXTrrykEp3KfEJv\r\n' ^
        //    'Content-Disposition: form-data; name=""bom""; filename=""{projectName}.bom""\r\n' ^
        //    'Content-Type: application/octet-stream\r\n' ^
        //    '\r\n{sbomJson}\r\n' ^
        //    '------WebKitFormBoundaryqBXTrrykEp3KfEJv--'";

        //ShellService.Service.Execute("curl",content, CdCommand.WorkingDirectory, output, useShellExecute: true);
    }
}