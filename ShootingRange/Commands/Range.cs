using System;

using CommandSystem;

using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace ShootingRange.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Range : ICommand
    {
        public string Command { get; } = "bc";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "把你送到靶场";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (PluginMain.Instance.Config.RequirePermission && !sender.CheckPermission("bc"))
            {
                response = "错误，您没有使用此命令的权限";
                return false;
            }

            if (!PluginMain.Instance.ActiveRange.TryAdmit(player))
            {
                response = "错误，您不是观众或该区域当前不可用";
                return false;
            }

            response = "命令成功";
            return true;
        }
    }
}
