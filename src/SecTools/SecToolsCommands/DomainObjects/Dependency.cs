namespace SecToolsCommands.DomainObjects;

public class Dependency
{
    public string _ref { get; set; }
    public object[] dependsOn { get; set; }
}