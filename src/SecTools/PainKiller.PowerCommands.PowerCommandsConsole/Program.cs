using PainKiller.PowerCommands.Core.Services;
using System.Reflection;

ConsoleService.Service.WriteLine(nameof(Program), @"__________ _________        _________                   ___________              .__            
\______   \\_   ___ \      /   _____/  ____   ____      \__    ___/____    ____  |  |    ______ 
 |     ___//    \  \/      \_____  \ _/ __ \_/ ___\       |    |  /  _ \  /  _ \ |  |   /  ___/ 
 |    |    \     \____     /        \\  ___/\  \___       |    | (  <_> )(  <_> )|  |__ \___ \  
 |____|     \______  /    /_______  / \___  >\___  >      |____|  \____/  \____/ |____//____  > 
                   \/             \/      \/     \/                                         \/  
                                                                                                ", ConsoleColor.DarkMagenta);
ConsoleService.Service.WriteHeaderLine(nameof(Program), $"\nVersion {ReflectionService.Service.GetVersion(Assembly.GetExecutingAssembly())}");
PainKiller.PowerCommands.Bootstrap.Startup.ConfigureServices().Run(args);