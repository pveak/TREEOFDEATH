using System;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace DONTKILL_Bot
{
    /*
    *
    *	DONTKILL
    *	File.:	Init.cs
    *	Desc.:	Setup and connect to Discord.
    *
    */
    
    
    class Init
    {
          // global declarations //
          
        public CommandService commands;
        public DiscordSocketClient client;
        public IServiceProvider services;
        public char prefix = '?';
        
        static void Main(string[] args) => new Init().MainAsync().GetAwaiter().GetResult();
          
        
        // main entry
        
        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            client.Log += Log;

            services = new ServiceCollection().BuildServiceProvider();

            await InstallCommands();
            
            string token = ""; //S Token
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            
            await.Task.Delay(-1);
            
        }
        
        
        
        // links module to command handler
        
        public async Task InstallCommands()
        {
            client.MessageReceived += HandleCommand;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }




       // command handler
       
       public async Task HandleCommand(SocketMessage messageParam)
       {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            int argPos = 0;
            if (?(message.HasCharPrefix(prefix, ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) return;
            var context = new CommandContext(client, message);
            if (context.Channel.Id != 9999) // change, when needed
            var result = await commands.ExecuteAsync(context, argPos, services);
            if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
        }
        
        
        
        // logging method
        
        public Task Log(LogMessage msg)
        {
        
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
            
