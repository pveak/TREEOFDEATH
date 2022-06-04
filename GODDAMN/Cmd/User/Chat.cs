using System.Threading.Tasks;
using Discord.Commands;
using DONTKILL.Utility;
using DONTKILL.Utility_Methods;

namespace DONTKILL_Bot.Command_Structure.User_Commands
{
    /*
    *
    * DONTKILL
    *	File.:	Chat.cs
    *	Desc.:	chat based commands for users.
    *
    */
    
      public class ChatUsers : ModuleBase
    {
        [Command("ping"), Summary("Returns \"Pong!\" if the bot is alive.")]
        public async Task Ping()
        {
            var embedBuilder = GlobalMethods.buildEmbed(new User(), "Ping");
            embedBuilder.WithDescription("Pong!");
            await ReplyAsync(null, false, embedBuilder);
        }
    }
}
