namespace SecToolsCommands.Configuration
{
    public class PowerCommandsConfiguration : CommandsConfiguration
    {
        public static string AppDataFolder = Path.Combine(ConfigurationGlobals.ApplicationDataFolder, "SecTools");
        public static string AppDataFolderDependencyTrack = Path.Combine(ConfigurationGlobals.ApplicationDataFolder, "SecTools","dependencytrack");
        public DockerDesktopConfiguration DockerDesktop { get; set; } = new();
        public CdxgenConfiguration Cdxgen { get; set; } = new();
        public DependencyTrackerConfiguration DependencyTracker { get; set; } = new();
        public EpssConfiguration Epss { get; set; } = new();
        public ToolbarConfiguration? StartupToolbar { get; set; }
    }
}