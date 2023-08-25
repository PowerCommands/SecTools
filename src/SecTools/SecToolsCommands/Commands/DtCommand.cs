using PainKiller.PowerCommands.Core.Commands;

namespace SecToolsCommands.Commands;

[PowerCommandTest(         tests: " ")]
[PowerCommandDesign( description: "Description of your command...",
                         example: "dt")]
public class DtCommand : CommandBase<PowerCommandsConfiguration>
{
    public DtCommand(string identifier, PowerCommandsConfiguration configuration) : base(identifier, configuration) { }

    public override RunResult Run()
    {

        
        return Ok();
    }
}