namespace SecToolsCommands.DomainObjects;

public class Component
{
    public string author { get; set; }
    public string publisher { get; set; }
    public string group { get; set; }
    public string name { get; set; }
    public string version { get; set; }
    public string description { get; set; }
    public object[] licenses { get; set; }
    public string purl { get; set; }
    public string type { get; set; }
    public string bomref { get; set; }
    public Property[] properties { get; set; }
}