using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MoreCommands.commands;
using System;
using System.Linq;

namespace MoreCommands
{
    [Plugin(PluginName = "MoreCommands", Description = "MoreCommands", PluginVersion = "1.0", Author = "bl_3an_dev")]
    public class Loader : Plugin
    {
        protected override void OnEnable()
        {
            Context.PluginManager.LoadCommands(new GamemodeCommand(this));
            Console.WriteLine("MoreCommands 플러그인이 활성화되었습니다.");
        }
        public override void OnDisable()
        {
            Console.WriteLine("MoreCommands 플러그인이 비활성화되었습니다.");
        }
        public Player GetPlayer(string name)
        {
            foreach (var i in Context.LevelManager.Levels)
            {
                return i.Players.ToList().Find(x => x.Value.Username.ToLower().Contains(name.ToLower())).Value ?? null;
            }
            return null;
        }
    }
}
