using System;

using CommandSystem;

using Exiled.API.Features;

namespace ShootingRange.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Spectate : ICommand
    {
        public string Command { get;} = "fh";

        public string[] Aliases { get;} = Array.Empty<string>();

        public string Description { get;} = "如果您在范围内，则返回到观察者";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (PluginMain.Instance.ActiveRange.HasPlayer(player))
            {
                player.ClearInventory();
                player.SetRole(RoleType.Spectator);
                response = "命令成功";
                return true;
            }

            response = "错误，您不在靶场上";
            return false;
        }
    }
}
