using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Boodbot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")] //echos text back
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Echo'd message");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("Hello")] //still working on this command
        public async Task Hello([Remainder]string message)
        {
            await Context.Channel.SendMessageAsync("@" + Context.User + " You suck.");
        }
    }
}
