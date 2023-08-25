namespace SecToolsCommands.DomainObjects;

public class Metadata
{
    public DateTime timestamp { get; set; }
    public Tool[] tools { get; set; }
    public Author[] authors { get; set; }
    public Component component { get; set; }
}