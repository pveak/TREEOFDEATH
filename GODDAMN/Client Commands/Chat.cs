using System.Security.Authentication;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DONTKILL.Utility;
using DONTKILL.Utility_Methods;

namespace DONTKILL_Bot.Command_Structure.Client_Commands
{
   /*
    *
    *   DONTKILL
    *	  File.: Chat.cs
    *	  Desc.: Chat based commands for Clients.
    *
    */
    
    public class ChatClient : ModuleBase
    {
        [Command("ping"), Summary("Returns \"Hi!\" if bot alive.")]
        public async Task Ping()
        {
              if (!GlobalMethods.authenticateCaller(new Client(), Context.Message.Author)) throw new AuthenticationException("Requires Client or >.");
            var embedBuilder = new EmbedBuilder();
            embedBuilder.WithDescription("On");
            await ReplyAsync(null, false, embedBuilder);
        }
    }
}
