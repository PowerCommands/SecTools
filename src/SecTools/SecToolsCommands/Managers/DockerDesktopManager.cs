namespace SecToolsCommands.Managers;
public static class DockerDesktopManager
{
    public static void StartDockerDesktop(string fullFileName, int startupTime)
    {
        Action<string> writer = s =>
        {
            ConsoleService.Service.WriteLine(nameof(DockerDesktopManager), s);
        };
        
        Action<string> reader = s =>
        {
            if (s.Trim().ToLower().EndsWith("server:"))
            {
                ShellService.Service.Execute(fullFileName, arguments: "", workingDirectory: "", writer, fileExtension: "");
                ConsoleService.Service.WriteLine(nameof(StartDockerDesktop), "Docker Desktop starting...");
                PauseService.Pause(startupTime);
                ConsoleService.Service.WriteSuccessLine(nameof(StartDockerDesktop), "Docker Desktop started!");
            }
            else { ConsoleService.Service.WriteSuccessLine(nameof(StartDockerDesktop), "Docker Desktop seems to be running already.");}
        };
        ShellService.Service.Execute("docker", arguments: "info", workingDirectory: "", reader, fileExtension: "", waitForExit: true);
    }
    public static void Pull(string image)
    {
        Console.WriteLine($"Pull image {image}... please wait, result will not show before the whole process is done.");
        ShellService.Service.Execute("docker", $"pull {image}", workingDirectory: "", waitForExit: true);
    }
}