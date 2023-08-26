namespace SecToolsCommands.Commands;

[PowerCommandDesign( description: "Edit dependency tracker docker-compose.yaml file",
                         options: "dependencytrack",
                         example: "//Open PowerCommandsConfiguration.yaml|config|//Open Dependency Track docker-compose.yaml file|config --dependencytrack")]
public class ConfigCommand : CommandBase<PowerCommandsConfiguration>
{
    public ConfigCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {
        ShellService.Service.Execute(Configuration.CodeEditor, arguments: HasOption("dependencytrack") ? Path.Combine(PowerCommandsConfiguration.AppDataFolderDependencyTrack, "docker-compose.yml") : $"{Path.Combine(AppContext.BaseDirectory, $"{nameof(PowerCommandsConfiguration)}.yaml")}", workingDirectory: "", WriteLine, fileExtension: "");
        return Ok();
    }
}