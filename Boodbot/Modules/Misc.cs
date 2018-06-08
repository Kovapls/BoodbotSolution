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
            await Context.Channel.SendMessageAsync("<@" + Context.User.Id + ">" + " You suck.");
        }

        [Command("FAQ")] //FAQ page will be linked like this
        public async Task FAQ()
        {
            await Context.Channel.SendMessageAsync("The FAQ for Boodbot can be found at: https://github.com/Kovapls/BoodbotSolution/blob/master/README.md");
        }

        [Command("Choose")] //choses between one or more options
        public async Task ChoseOne([Remainder]string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("Choice for " + Context.User.Username);
            embed.WithDescription(selection);
            embed.WithColor(new Color(47, 91, 229));
            embed.WithThumbnailUrl("https://i.imgur.com/OpKAELs.gif");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("Bill")]
        public async Task BillNye()
        {
            Random r = new Random();

            int numberGenned = r.Next(1,5);

            if (numberGenned == 4)
            {
                await Context.Channel.SendMessageAsync("https://i.imgur.com/xPLHck1.jpg");
            }
            else
            {
                await Context.Channel.SendMessageAsync("BILL BILL BILL BILL BILL BILL! \n\n https://www.youtube.com/watch?v=UtVJdPfm0F8");
            }
            
        }


        [Command("Commands")] //command listng
        public async Task Commands()
        {
            await Context.Channel.SendMessageAsync("Commands currently implemented are: !Hello, !FAQ, !Choose, !Bill, !Echo. I will add more whenever I feel like it.");
        }
    }
}
