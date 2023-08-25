namespace SecToolsCommands.DomainObjects;

public class SbomV14
{
    public string bomFormat { get; set; }
    public string specVersion { get; set; }
    public string serialNumber { get; set; }
    public int version { get; set; }
    public Metadata metadata { get; set; }
    public Component[] components { get; set; }
    public object[] services { get; set; }
    public Dependency[] dependencies { get; set; }
}