using System.Security.Authentication;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DONTKILL.Utility;
using DONTKILL.Utility_Methods;

namespace DONTKILL_Bot.Command_Structure.User_Commands
{
    /*
    *
    *   DONTKILL
    *	  File.: Chat.cs
    *	  Desc.: Chat based commands for Developers.
    *
    */
    
     public class ChatDev : ModuleBase
     {
        [Command("ping"), Summary("Returns \"Hi!\" if bot alive.")]
        public async Task Ping()
        {
            if (!GlobalMethods.authenticateCaller(new Developer(), Context.Message.Author)) throw new AuthenticationException("Requires Developer or >.");
            var embedBuilder = new EmbedBuilder();
            embedBuilder.WithDescription("On");
            await ReplyAsync(null, false, embedBuilder);
        }
    }
}
