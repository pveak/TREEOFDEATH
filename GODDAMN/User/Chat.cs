using System.Threading.Tasks;
using Discord.Commands;
using DONTKILL.Utility;
using DONTKILL.Utility_Methods;

namespace DONTKILL_Bot.Command_Structure.User_Commands
{
    /*
    *
    *   DONTKILL
    *	File.:	Chat.cs
    *	Desc.:	Chat based commands for users.
    *
    */
    
      public class ChatUsers : ModuleBase
    {
        [Command("ping"), Summary("Returns \"Hi!\" if bot alive.")]
        public async Task Ping()
        {
            var embedBuilder = GlobalMethods.buildEmbed(new User(), "Ping");
            embedBuilder.WithDescription("On");
            await ReplyAsync(null, false, embedBuilder);
        }
    }
}
