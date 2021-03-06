﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Boodbot
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        DiscordSocketClient _client2;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _client2 = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
            _client2.MessageReceived += HandleKeywordAsync; 
        }

        private async Task HandleCommandAsync(SocketMessage s) //handles the command parsing
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;

            //defines what command the bot will use in the config file. Can also mention or @ the bot
            if(msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);

                //verifies that the command goes through and is valid
                if(!result.IsSuccess && result.Error !=CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.Error); //helps create error messages
                }


            }
        }

        private async Task HandleKeywordAsync(SocketMessage s) //this is my test method
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client2, msg);
            //int argPos = 0;
            string msgUpper = msg.Content.ToString().ToUpper();   //ToString().ToUpper();
            //string contextSender = msg.Id.ToString(); //msg.Author.ToString();
            
            if (context.User.IsBot == true && context.User.Id != 453991944050311198)
            {
                await context.Channel.SendMessageAsync("<@" + context.User.Id + ">" + "Oy. I am the superior bot. " +
                                                        "This town ain't big enough for the both of us");
            }


            if (msgUpper.Contains("BIG MOOD"))
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " Bood."); //mention
            }
            else if (msgUpper.Contains("B I G M O O D"))
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " B O O D."); //mention
            }
            else if (msgUpper.Contains("BOOD?"))
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " Yeah, **B**ig M**ood** \n\n" + " https://youtu.be/CHzsIjquBRA?t=22s"); //mention
            }
            else if (msgUpper.Contains("BLEASE") && msg.Author.Id.ToString() != Config.bot.botID)
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " I'll Blease you."); //what happens if someone says "blease"
            }
            else if (msgUpper.Contains("<@" + Config.bot.botID + ">") && msg.Author.Id.ToString() != Config.bot.botID)
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " Dont @ me."); //This is for when someone @'s my bot
            }
            else if (msgUpper.Contains("<@" + Config.bot.KovaID + ">") && msg.Author.Id.ToString() != Config.bot.botID)
            {
                await context.Channel.SendMessageAsync("<@" + msg.Author.Id + ">" + " Don't @ him, either."); //For when someone @'s me
            }


        }
    }
} 
