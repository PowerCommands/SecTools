namespace SecToolsCommands.Configuration
{
    public class PowerCommandsConfiguration : CommandsConfiguration
    {
        public string PathToDockerDesktop { get; set; } = "";
        public string SdxGenServerVolumeMount { get; set; } = "";
        public string UrlToDockerComposeFile { get; set; } = "";
        public ToolbarConfiguration? StartupToolbar { get; set; }
    }
}