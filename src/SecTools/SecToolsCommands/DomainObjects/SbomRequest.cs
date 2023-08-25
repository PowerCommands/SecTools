namespace SecToolsCommands.DomainObjects;

public class SbomRequest
{
    public string autoRequest { get; set; } = "true";
    public string projectName { get; set; } = string.Empty;
    public SbomV14? body { get; set; }
    
}