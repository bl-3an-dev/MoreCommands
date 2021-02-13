using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Worlds;
using System;
using System.Linq;

namespace MoreCommands.commands
{
    public class GamemodeCommand
    {
        private Loader Owner;
        public GamemodeCommand(Loader owner)
        {
            Owner = owner;
        }
        [Command(Name = "gamemode", Aliases = new[] { "gm" }, Description = "플레이어를 특정 게임 모드로 변경합니다.")]
        public void Execute(Player player, int mode, Target target = null)
        {

            Player targetPlayer = player;

            if (target != null)
                targetPlayer = Owner.GetPlayer(target.ToString());

            if (targetPlayer == null)
            {
                player.SendMessage("플레이어를 찾을 수 없습니다.");
                return;
            }

            targetPlayer.SetGameMode((GameMode)mode);

            if (player == targetPlayer)
            {
                player.SendMessage($"내 게임 모드를 {GamemodeName(mode)} 모드(으)로 변경했습니다.");
            }
            else
            {
                player.SendMessage($"{targetPlayer.Username}님의 게임 모드를 {GamemodeName(mode)} 모드(으)로 변경했습니다.");
                targetPlayer.SendMessage($"게임 모드가 {GamemodeName(mode)} 모드(으)로 업데이트되었습니다.");
            }

        }
        public static string GamemodeName(int gamemode)
        {
            if (gamemode == 0)
            {
                return "서바이벌";
            }
            else if (gamemode == 1)
            {
                return "크리에이티브";
            }
            else if (gamemode == 2)
            {
                return "모험";
            }
            else if (gamemode == 3)
            {
                return "관람자";
            }
            else
            {
                return "알수없음";
            }
        }
    }
}
